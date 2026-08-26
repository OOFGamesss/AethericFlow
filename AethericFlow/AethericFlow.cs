using AethericFlow.Config;
using AethericFlow.Events;
using AethericFlow.GameData;
using AethericFlow.Services;
using AethericFlow.State;
using AethericFlow.UI;
using AethericFlow.Unlocks;
using AethericFlow.Utility;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace AethericFlow;

public sealed class Plugin : IDalamudPlugin
{
    private const string ConfigCommand = "/aethericflow";
    private const string TeleportCommand = "/aftp";
    private const string TeleportCommandAlias = "/aethericflowtp";

    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;
    [PluginService] internal static IChatGui ChatGui { get; private set; } = null!;
    [PluginService] internal static IClientState ClientState { get; private set; } = null!;
    [PluginService] internal static IDataManager DataManager { get; private set; } = null!;
    [PluginService] internal static IAetheryteList AetheryteList { get; private set; } = null!;
    [PluginService] internal static IObjectTable ObjectTable { get; private set; } = null!;
    [PluginService] internal static ITextureProvider TextureProvider { get; private set; } = null!;
    [PluginService] internal static IPluginLog Log { get; private set; } = null!;

    private readonly WindowSystem windowSystem = new("AethericFlow");
    private readonly Configuration configuration;
    private readonly ConfigWindow configWindow;
    private readonly TeleportLinkRegistry linkRegistry;
    private readonly LatestTeleportTarget latestTarget;
    private readonly LatestLinkTeleporter latestTeleporter;
    private readonly ChatMessageListener chatListener;

    public Plugin()
    {
        configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

        var finder = new NearestAetheryteFinder(
            new AetheryteLocationCache(DataManager),
            new AttunementChecker(AetheryteList));

        linkRegistry = new TeleportLinkRegistry(ChatGui, configuration);
        latestTarget = new LatestTeleportTarget(ClientState);
        latestTeleporter = new LatestLinkTeleporter(ChatGui, latestTarget, configuration);
        chatListener = new ChatMessageListener(
            ChatGui,
            configuration,
            finder,
            new TeleportLinkBuilder(linkRegistry, configuration),
            latestTarget,
            new CloserOnFootCheck(ClientState, ObjectTable));

        configWindow = new ConfigWindow(configuration);
        windowSystem.AddWindow(configWindow);

        PluginInterface.UiBuilder.Draw += windowSystem.Draw;
        PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUi;
        PluginInterface.UiBuilder.OpenMainUi += ToggleConfigUi;

        CommandManager.AddHandler(ConfigCommand, new CommandInfo(OnConfigCommand)
        {
            HelpMessage = LocalisedText.ConfigCommandHelp.Text,
        });

        CommandManager.AddHandler(TeleportCommand, new CommandInfo(OnTeleportCommand)
        {
            HelpMessage = LocalisedText.TeleportCommandHelp.Text,
        });

        CommandManager.AddHandler(TeleportCommandAlias, new CommandInfo(OnTeleportCommand)
        {
            HelpMessage = LocalisedText.TeleportAliasHelp.Text,
        });
    }

    private void OnConfigCommand(string command, string arguments) => ToggleConfigUi();

    private void OnTeleportCommand(string command, string arguments) => latestTeleporter.Teleport();

    private void ToggleConfigUi() => configWindow.Toggle();

    public void Dispose()
    {
        CommandManager.RemoveHandler(TeleportCommandAlias);
        CommandManager.RemoveHandler(TeleportCommand);
        CommandManager.RemoveHandler(ConfigCommand);

        PluginInterface.UiBuilder.OpenMainUi -= ToggleConfigUi;
        PluginInterface.UiBuilder.OpenConfigUi -= ToggleConfigUi;
        PluginInterface.UiBuilder.Draw -= windowSystem.Draw;

        windowSystem.RemoveAllWindows();
        configWindow.Dispose();

        chatListener.Dispose();
        latestTarget.Dispose();
        linkRegistry.Dispose();
    }
}
