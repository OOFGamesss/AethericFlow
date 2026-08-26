using System.Numerics;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace AethericFlow.Actions;

/// <summary>
/// Drops the map flag on a map link so its destination shows on the map, minimap and compass.
/// </summary>
public static class MapFlagAction
{
    public static unsafe void Execute(MapLinkPayload mapLink)
    {
        var agent = AgentMap.Instance();

        if (agent == null)
        {
            Plugin.Log.Warning("Could not place a map flag, the map agent was unavailable.");
            return;
        }

        var position = new Vector3(mapLink.RawX / 1000f, 0f, mapLink.RawY / 1000f);
        agent->SetFlagMapMarker(mapLink.TerritoryType.RowId, mapLink.Map.RowId, position);
    }
}
