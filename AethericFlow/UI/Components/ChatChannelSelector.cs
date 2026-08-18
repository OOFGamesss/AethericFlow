using System.Collections.Generic;
using AethericFlow.Utility;
using Dalamud.Bindings.ImGui;
using Dalamud.Game.Text;
using Dalamud.Interface.Utility.Raii;

namespace AethericFlow.UI.Components;

/// <summary>
/// Draws the grid of chat channel toggles used by the configuration window.
/// </summary>
public static class ChatChannelSelector
{
    private const int ColumnCount = 2;

    public static bool Draw(ISet<XivChatType> enabledChannels)
    {
        using var table = ImRaii.Table("##aethericFlowChannels", ColumnCount);
        if (!table)
        {
            return false;
        }

        var changed = false;
        foreach (var (type, label) in ChatChannelCatalogue.All)
        {
            ImGui.TableNextColumn();
            changed |= DrawToggle(enabledChannels, type, label);
        }

        return changed;
    }

    private static bool DrawToggle(ISet<XivChatType> enabledChannels, XivChatType type, LocalisedString label)
    {
        var enabled = enabledChannels.Contains(type);
        if (!ImGui.Checkbox($"{label.Text}##channel{(int)type}", ref enabled))
        {
            return false;
        }

        if (enabled)
        {
            enabledChannels.Add(type);
        }
        else
        {
            enabledChannels.Remove(type);
        }

        return true;
    }
}
