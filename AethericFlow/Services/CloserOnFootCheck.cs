using System.Numerics;
using AethericFlow.GameData;
using AethericFlow.Utility;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Plugin.Services;
using Dalamud.Utility;

namespace AethericFlow.Services;

/// <summary>
/// Reports whether the player already stands closer to a map link than the aetheryte picked for it.
/// </summary>
public sealed class CloserOnFootCheck(IClientState clientState, IObjectTable objectTable)
{
    private const float MarginInMapUnits = 2f;

    public bool IsCloserOnFoot(MapLinkPayload mapLink, AetheryteLocation aetheryte)
    {
        if (clientState.TerritoryType != mapLink.TerritoryType.RowId || objectTable.LocalPlayer is not { } player)
        {
            return false;
        }

        var position = MapUtil.WorldToMap(new Vector2(player.Position.X, player.Position.Z), mapLink.Map.Value);
        var onFoot = MapCoordinates.DistanceBetween(mapLink.XCoord, mapLink.YCoord, position.X, position.Y);
        var byAetheryte = MapCoordinates.DistanceBetween(mapLink.XCoord, mapLink.YCoord, aetheryte.X, aetheryte.Y);

        Plugin.Log.Debug("Walk hint: {OnFoot:F1} away on foot, {ByAetheryte:F1} from {Aetheryte}.", onFoot, byAetheryte, aetheryte.Name);

        return onFoot + MarginInMapUnits < byAetheryte;
    }
}
