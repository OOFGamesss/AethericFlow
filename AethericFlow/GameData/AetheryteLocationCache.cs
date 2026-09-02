using System.Collections.Generic;
using System.Linq;
using AethericFlow.Utility;
using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;

namespace AethericFlow.GameData;


/// <summary>
/// Builds a one off lookup of every teleportable aetheryte, keyed by the territory it serves.
/// </summary>
public readonly record struct AetheryteLocation(uint RowId, string Name, float X, float Y);

public sealed class AetheryteLocationCache
{
    public const uint DravanianHinterlands = 399;

    private const uint Idyllshire = 478;
    private const uint DravanianForelands = 398;
    private const uint CoerthasWesternHighlands = 397;

    private readonly Dictionary<uint, List<AetheryteLocation>> locationsByTerritory;

    public AetheryteLocationCache(IDataManager dataManager)
    {
        locationsByTerritory = BuildLocations(dataManager, BuildMarkerPositions(dataManager));
    }

    public IReadOnlyList<AetheryteLocation> ForTerritory(uint territoryTypeId)
    {
        return locationsByTerritory.TryGetValue(territoryTypeId, out var locations) ? locations : [];
    }

    private static Dictionary<uint, (float X, float Y)> BuildMarkerPositions(IDataManager dataManager)
    {
        var positions = new Dictionary<uint, (float X, float Y)>();

        foreach (var marker in dataManager.GetSubrowExcelSheet<MapMarker>().SelectMany(subrows => subrows))
        {
            if (marker.DataType is 3 or 4)
            {
                positions.TryAdd(marker.DataKey.RowId, (marker.X, marker.Y));
            }
        }

        return positions;
    }

    private static Dictionary<uint, List<AetheryteLocation>> BuildLocations(
        IDataManager dataManager,
        Dictionary<uint, (float X, float Y)> markerPositions)
    {
        var locations = new Dictionary<uint, List<AetheryteLocation>>();
        var hubsByGroup = new Dictionary<int, AetheryteLocation>();
        var sheet = dataManager.GetExcelSheet<Aetheryte>();

        foreach (var aetheryte in sheet)
        {
            TryAddTeleportable(aetheryte, markerPositions, locations, hubsByGroup);
        }

        AethernetHubFallback.Apply(sheet, locations, hubsByGroup);

        if (!locations.ContainsKey(DravanianHinterlands))
        {
            var neighbours = new List<AetheryteLocation>();

            foreach (var territory in new uint[] { Idyllshire, DravanianForelands, CoerthasWesternHighlands })
            {
                if (locations.ContainsKey(territory))
                {
                    neighbours.AddRange(locations[territory]);
                }
            }

            if (neighbours.Count > 0)
            {
                locations[DravanianHinterlands] = neighbours;
            }
        }

        return locations;
    }

    private static void TryAddTeleportable(
        Aetheryte aetheryte,
        Dictionary<uint, (float X, float Y)> markerPositions,
        Dictionary<uint, List<AetheryteLocation>> locations,
        Dictionary<int, AetheryteLocation> hubsByGroup)
    {
        if (!IsTeleportable(aetheryte) || !markerPositions.TryGetValue(aetheryte.RowId, out var marker))
        {
            return;
        }

        var location = ToLocation(aetheryte, marker);
        locations.TryAdd(aetheryte.Territory.RowId, []);
        locations[aetheryte.Territory.RowId].Add(location);

        if (aetheryte.AethernetGroup != 0)
        {
            hubsByGroup.TryAdd(aetheryte.AethernetGroup, location);
        }
    }

    private static AetheryteLocation ToLocation(Aetheryte aetheryte, (float X, float Y) marker)
    {
        var (x, y) = MapCoordinates.FromMarker(marker.X, marker.Y, aetheryte.Map.Value.SizeFactor);
        return new AetheryteLocation(aetheryte.RowId, aetheryte.PlaceName.Value.Name.ExtractText(), x, y);
    }

    private static bool IsTeleportable(Aetheryte aetheryte)
    {
        return aetheryte.IsAetheryte && !aetheryte.Invisible && aetheryte.Territory.RowId != 0;
    }
}
