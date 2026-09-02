using System.Linq;
using AethericFlow.GameData;
using AethericFlow.Unlocks;
using AethericFlow.Utility;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace AethericFlow.Services;

/// <summary>
/// Picks the attuned aetheryte that sits closest to a map link in the zone it serves.
/// </summary>
public sealed class NearestAetheryteFinder(AetheryteLocationCache locations, AttunementChecker attunement)
{
    public AetheryteLocation? Find(MapLinkPayload mapLink)
    {
        var candidates = locations.ForTerritory(mapLink.TerritoryType.RowId)
            .Where(location => attunement.IsAttuned(location.RowId))
            .ToList();

        if (candidates.Count == 0)
        {
            return null;
        }

        if (mapLink.TerritoryType.RowId == AetheryteLocationCache.DravanianHinterlands)
        {
            return candidates[0];
        }

        return candidates.MinBy(location =>
            MapCoordinates.DistanceBetween(mapLink.XCoord, mapLink.YCoord, location.X, location.Y));
    }
}
