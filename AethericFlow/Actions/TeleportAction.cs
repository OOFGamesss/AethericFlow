using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace AethericFlow.Actions;

/// <summary>
/// Asks the game to teleport the local character to an aetheryte.
/// </summary>
public static class TeleportAction
{
    public static unsafe void Execute(uint aetheryteId)
    {
        var telepo = Telepo.Instance();

        if (telepo == null || !telepo->Teleport(aetheryteId, 0))
        {
            Plugin.Log.Warning("Could not teleport to aetheryte {AetheryteId}.", aetheryteId);
        }
    }
}
