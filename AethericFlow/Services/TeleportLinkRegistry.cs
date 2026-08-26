using System;
using System.Collections.Generic;
using AethericFlow.Actions;
using AethericFlow.Config;
using AethericFlow.GameData;
using AethericFlow.State;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Plugin.Services;

namespace AethericFlow.Services;

/// <summary>
/// Owns the chat link handlers, registering one per aetheryte so the command id carries the destination.
/// </summary>
public sealed class TeleportLinkRegistry(IChatGui chatGui, Configuration configuration) : IDisposable
{
    private readonly Dictionary<uint, DalamudLinkPayload> payloads = [];
    private readonly Dictionary<uint, TeleportTarget> targets = [];

    public DalamudLinkPayload PayloadFor(AetheryteLocation aetheryte, MapLinkPayload mapLink)
    {
        targets[aetheryte.RowId] = new TeleportTarget(aetheryte, mapLink);

        if (!payloads.TryGetValue(aetheryte.RowId, out var payload))
        {
            payload = chatGui.AddChatLinkHandler(aetheryte.RowId, OnLinkClicked);
            payloads[aetheryte.RowId] = payload;
        }

        return payload;
    }

    private void OnLinkClicked(uint aetheryteId, SeString link)
    {
        if (targets.TryGetValue(aetheryteId, out var target))
        {
            TeleportAction.Execute(target, configuration.PlaceMapFlag);
        }
    }

    public void Dispose()
    {
        chatGui.RemoveChatLinkHandler();
        payloads.Clear();
        targets.Clear();
    }
}
