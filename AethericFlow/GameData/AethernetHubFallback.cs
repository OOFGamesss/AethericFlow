using System.Collections.Generic;
using System.Linq;
using Lumina.Excel.Sheets;

namespace AethericFlow.GameData;

/// <summary>
/// Maps city districts that only have aethernet shards onto the teleportable crystal for that network.
/// </summary>
public static class AethernetHubFallback
{
    public static void Apply(
        IEnumerable<Aetheryte> aetherytes,
        Dictionary<uint, List<AetheryteLocation>> locations,
        IReadOnlyDictionary<int, AetheryteLocation> hubsByGroup)
    {
        foreach (var shard in aetherytes)
        {
            TryMapShard(shard, locations, hubsByGroup);
        }
    }

    private static void TryMapShard(
        Aetheryte shard,
        Dictionary<uint, List<AetheryteLocation>> locations,
        IReadOnlyDictionary<int, AetheryteLocation> hubsByGroup)
    {
        if (!IsUnservedDistrictShard(shard, locations))
        {
            return;
        }

        if (!hubsByGroup.TryGetValue(shard.AethernetGroup, out var hub))
        {
            return;
        }

        AddHub(locations, shard.Territory.RowId, hub);
    }

    private static bool IsUnservedDistrictShard(
        Aetheryte shard,
        Dictionary<uint, List<AetheryteLocation>> locations)
    {
        return !shard.IsAetheryte
            && !shard.Invisible
            && shard.Territory.RowId != 0
            && shard.AethernetGroup != 0
            && !locations.ContainsKey(shard.Territory.RowId);
    }

    private static void AddHub(
        Dictionary<uint, List<AetheryteLocation>> locations,
        uint territoryId,
        AetheryteLocation hub)
    {
        locations.TryAdd(territoryId, []);

        if (locations[territoryId].Any(location => location.RowId == hub.RowId))
        {
            return;
        }

        locations[territoryId].Add(hub);
    }
}
