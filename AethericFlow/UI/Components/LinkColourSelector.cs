using System.Numerics;
using AethericFlow.Config;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using Lumina.Excel.Sheets;

namespace AethericFlow.UI.Components;

/// <summary>
/// Draws the row of swatches used to pick the colour of the teleport link.
/// </summary>
public static class LinkColourSelector
{
    private const float SwatchSize = 20f;
    private const float SelectedBorderSize = 2f;
    private const int SwatchesPerRow = 6;

    private static readonly ushort[] Keys =
    [
        500, 527, 506, 504, 575, 502,
        542, 522, 524, 518, 521, 3,
    ];

    public static bool Draw(Configuration configuration)
    {
        var changed = false;

        for (var index = 0; index < Keys.Length; index++)
        {
            if (index % SwatchesPerRow != 0)
            {
                ImGui.SameLine();
            }

            changed |= DrawSwatch(configuration, Keys[index]);
        }

        return changed;
    }

    private static bool DrawSwatch(Configuration configuration, ushort key)
    {
        var colour = ColourFor(key);
        using var fill = ImRaii.PushColor(ImGuiCol.Button, colour)
            .Push(ImGuiCol.ButtonHovered, colour)
            .Push(ImGuiCol.ButtonActive, colour)
            .Push(ImGuiCol.Border, Vector4.One);
        using var border = ImRaii.PushStyle(
            ImGuiStyleVar.FrameBorderSize,
            configuration.LinkColour == key ? SelectedBorderSize : 0f);

        var size = SwatchSize * ImGuiHelpers.GlobalScale;
        if (!ImGui.Button($"##aethericFlowColour{key}", new Vector2(size, size)))
        {
            return false;
        }

        configuration.LinkColour = key;
        return true;
    }

    private static Vector4 ColourFor(ushort key)
    {
        return Plugin.DataManager.GetExcelSheet<UIColor>().GetRowOrDefault(key) is not { } row
            ? Vector4.One
            : ImGui.ColorConvertU32ToFloat4(ColorHelpers.SwapEndianness(row.Dark));
    }
}
