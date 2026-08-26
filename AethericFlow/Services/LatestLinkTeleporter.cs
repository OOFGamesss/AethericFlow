using AethericFlow.Actions;
using AethericFlow.Config;
using AethericFlow.State;
using AethericFlow.Utility;
using Dalamud.Plugin.Services;

namespace AethericFlow.Services;

/// <summary>
/// Teleports to the aetheryte from the most recent map link, for players driving the plugin from a macro.
/// </summary>
public sealed class LatestLinkTeleporter(IChatGui chatGui, LatestTeleportTarget target, Configuration configuration)
{
    public void Teleport()
    {
        if (target.Current is not { } destination)
        {
            chatGui.PrintError(LocalisedText.NoMapLinkSeen.Text, "Aetheric Flow");
            return;
        }

        TeleportAction.Execute(destination, configuration.PlaceMapFlag);
    }
}
