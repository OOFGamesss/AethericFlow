using AethericFlow.State;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace AethericFlow.Actions;

/// <summary>
/// Teleports the playerto the aetheryte for a map link, flagging the destination on the way.
/// </summary>
public static class TeleportAction
{
    public static unsafe void Execute(TeleportTarget target, bool placeMapFlag)
    {
        if (placeMapFlag)
        {
            MapFlagAction.Execute(target.MapLink);
        }

        var telepo = Telepo.Instance();

        if (telepo == null || !telepo->Teleport(target.Aetheryte.RowId, 0))
        {
            Plugin.Log.Warning("Could not teleport to aetheryte {AetheryteId}.", target.Aetheryte.RowId);
        }
    }
}
