using System;
using AethericFlow.GameData;
using Dalamud.Plugin.Services;

namespace AethericFlow.State;

/// <summary>
/// Remembers the aetheryte from the most recent map link so a command can reach it without a mouse click.
/// </summary>
public sealed class LatestTeleportTarget : IDisposable
{
    private readonly IClientState clientState;

    public LatestTeleportTarget(IClientState clientState)
    {
        this.clientState = clientState;
        this.clientState.Logout += OnLogout;
    }

    public AetheryteLocation? Current { get; private set; }

    public void Remember(AetheryteLocation aetheryte)
    {
        Current = aetheryte;
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
