using System;
using System.Linq;
using AethericFlow.Config;
using AethericFlow.Services;
using AethericFlow.State;
using Dalamud.Game.Chat;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Plugin.Services;

namespace AethericFlow.Events;

/// <summary>
/// Watches incoming chat for map links and appends a teleport link to the nearest attuned aetheryte.
/// </summary>
public sealed class ChatMessageListener : IDisposable
{
    private readonly IChatGui chatGui;
    private readonly Configuration configuration;
    private readonly NearestAetheryteFinder finder;
    private readonly TeleportLinkBuilder builder;
    private readonly LatestTeleportTarget latestTarget;

    public ChatMessageListener(
        IChatGui chatGui,
        Configuration configuration,
        NearestAetheryteFinder finder,
        TeleportLinkBuilder builder,
        LatestTeleportTarget latestTarget)
    {
        this.chatGui = chatGui;
        this.configuration = configuration;
        this.finder = finder;
        this.builder = builder;
        this.latestTarget = latestTarget;

        this.chatGui.ChatMessage += OnChatMessage;
    }

    private void OnChatMessage(IHandleableChatMessage message)
    {
        try
        {
            AppendTeleportLink(message);
        }
        catch (Exception exception)
        {
            Plugin.Log.Error(exception, "Failed to append a teleport link.");
        }
    }

    private void AppendTeleportLink(IHandleableChatMessage message)
    {
        if (!configuration.EnabledChannels.Contains(message.LogKind))
        {
            return;
        }

        var mapLink = message.Message.Payloads.OfType<MapLinkPayload>().FirstOrDefault();
        if (mapLink == null || finder.Find(mapLink) is not { } aetheryte)
        {
            return;
        }

        latestTarget.Remember(aetheryte);
        message.Message = builder.Append(message.Message, aetheryte);
    }

    public void Dispose()
    {
        chatGui.ChatMessage -= OnChatMessage;
    }
}
