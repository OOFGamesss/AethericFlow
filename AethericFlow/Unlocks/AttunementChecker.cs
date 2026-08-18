using System.Linq;
using Dalamud.Plugin.Services;

namespace AethericFlow.Unlocks;

/// <summary>
/// Reports whether the player has already attuned to a given aetheryte.
/// </summary>
public sealed class AttunementChecker(IAetheryteList aetheryteList)
{
    public bool IsAttuned(uint aetheryteId)
    {
        return aetheryteList.Any(entry => entry.AetheryteId == aetheryteId);
    }
}
