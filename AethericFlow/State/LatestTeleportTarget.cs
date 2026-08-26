using System;
using AethericFlow.GameData;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Plugin.Services;

namespace AethericFlow.State;

/// <summary>
/// Remembers the map link and aetheryte from the most recent teleport link, so a command can reach it
/// without a mouse click.
/// </summary>
public readonly record struct TeleportTarget(AetheryteLocation Aetheryte, MapLinkPayload MapLink);

public sealed class LatestTeleportTarget : IDisposable
{
    private readonly IClientState clientState;

    public LatestTeleportTarget(IClientState clientState)
    {
        this.clientState = clientState;
        this.clientState.Logout += OnLogout;
    }

    public TeleportTarget? Current { get; private set; }

    public void Remember(AetheryteLocation aetheryte, MapLinkPayload mapLink)
    {
        Current = new TeleportTarget(aetheryte, mapLink);
    }

    private void OnLogout(int type, int code)
    {
        Current = null;
    }

    public void Dispose()
    {
        clientState.Logout -= OnLogout;
    }
}
