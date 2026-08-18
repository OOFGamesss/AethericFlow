using System;
using System.Collections.Generic;
using AethericFlow.Actions;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Plugin.Services;

namespace AethericFlow.Services;

/// <summary>
/// Owns the chat link handlers, registering one per aetheryte so the command id carries the destination.
/// </summary>
public sealed class TeleportLinkRegistry(IChatGui chatGui) : IDisposable
{
    private readonly Dictionary<uint, DalamudLinkPayload> payloads = [];

    public DalamudLinkPayload PayloadFor(uint aetheryteId)
    {
        if (!payloads.TryGetValue(aetheryteId, out var payload))
        {
            payload = chatGui.AddChatLinkHandler(aetheryteId, OnLinkClicked);
            payloads[aetheryteId] = payload;
        }

        return payload;
    }

    private static void OnLinkClicked(uint aetheryteId, SeString link)
    {
        TeleportAction.Execute(aetheryteId);
    }

    public void Dispose()
    {
        chatGui.RemoveChatLinkHandler();
        payloads.Clear();
    }
}
