using System;
using System.Numerics;
using AethericFlow.Config;
using AethericFlow.UI.Components;
using AethericFlow.Utility;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Interface.Windowing;

namespace AethericFlow.UI;

/// <summary>
/// The plugin window, holding the settings sections and the support page.
/// </summary>
public sealed class ConfigWindow : Window, IDisposable
{
    private const float SectionSpacing = 8f;
    private const float TooltipWrapWidth = 20f;

    private readonly Configuration configuration;

    public ConfigWindow(Configuration configuration) : base("Aetheric Flow###AethericFlowConfig")
    {
        this.configuration = configuration;

        Size = new Vector2(440, 440);
        SizeCondition = ImGuiCond.FirstUseEver;
    }

    public override void Draw()
    {
        using var tabs = ImRaii.TabBar("##aethericFlowTabs");
        if (!tabs)
        {
            return;
        }

        DrawSettingsTab();
        DrawSupportTab();
    }

    private void DrawSettingsTab()
    {
        using var tab = ImRaii.TabItem($"{LocalisedText.SettingsTab.Text}###aethericFlowSettings");
        if (!tab)
        {
            return;
        }

        var changed = DrawGeneralSection();
        changed |= DrawChannelSection();
        changed |= DrawAppearanceSection();

        if (changed)
        {
            configuration.Save();
        }
    }

    private bool DrawGeneralSection()
    {
        DrawSectionHeading(LocalisedText.SettingsGeneral);

        var changed = DrawToggle(LocalisedText.WalkHintToggle, configuration.ShowWalkHint, out var showWalkHint);
        configuration.ShowWalkHint = showWalkHint;

        changed |= DrawToggle(LocalisedText.MapFlagToggle, configuration.PlaceMapFlag, out var placeMapFlag);
        configuration.PlaceMapFlag = placeMapFlag;

        ImGuiHelpers.ScaledDummy(SectionSpacing);
        return changed;
    }

    private bool DrawClockIconToggle()
    {
        using var disabled = ImRaii.Disabled(!configuration.ShowWalkHint);

        var changed = DrawToggle(
            LocalisedText.ClockIconOnlyToggle,
            LocalisedText.ClockIconOnlyTooltip,
            configuration.ShowClockIconOnly,
            out var clockIconOnly);

        configuration.ShowClockIconOnly = clockIconOnly;
        return changed;
    }

    private bool DrawChannelSection()
    {
        DrawSectionHeading(LocalisedText.SettingsChannels);
        ImGui.TextWrapped(LocalisedText.SettingsIntro.Text);

        var changed = ChatChannelSelector.Draw(configuration.EnabledChannels);

        ImGuiHelpers.ScaledDummy(SectionSpacing);
        return changed;
    }

    private bool DrawAppearanceSection()
    {
        DrawSectionHeading(LocalisedText.SettingsAppearance);

        var changed = DrawToggle(
            LocalisedText.TeleportIconOnlyToggle,
            LocalisedText.TeleportIconOnlyTooltip,
            configuration.ShowTeleportIconOnly,
            out var teleportIconOnly);

        configuration.ShowTeleportIconOnly = teleportIconOnly;

        changed |= DrawClockIconToggle();

        ImGui.TextWrapped(LocalisedText.LinkColourLabel.Text);

        return changed | LinkColourSelector.Draw(configuration);
    }

    private static void DrawSectionHeading(LocalisedString heading)
    {
        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.DalamudGrey))
        {
            ImGui.TextUnformatted(heading.Text);
        }

        ImGui.Separator();
    }

    private static bool DrawToggle(LocalisedString label, bool current, out bool updated)
    {
        updated = current;
        return ImGui.Checkbox(label.Text, ref updated);
    }

    private static bool DrawToggle(LocalisedString label, LocalisedString tooltip, bool current, out bool updated)
    {
        var changed = DrawToggle(label, current, out updated);
        DrawTooltip(tooltip);

        return changed;
    }

    private static void DrawTooltip(LocalisedString tooltip)
    {
        if (!ImGui.IsItemHovered())
        {
            return;
        }

        using var wrapper = ImRaii.Tooltip();
        using var wrapping = ImRaii.TextWrapPos(ImGui.GetFontSize() * TooltipWrapWidth);

        ImGui.TextUnformatted(tooltip.Text);
    }

    private void DrawSupportTab()
    {
        using var tab = ImRaii.TabItem($"{LocalisedText.SupportTab.Text}###aethericFlowSupport");
        if (!tab)
        {
            return;
        }

        SupportPanel.Draw();
    }

    public void Dispose()
    {
    }
}
