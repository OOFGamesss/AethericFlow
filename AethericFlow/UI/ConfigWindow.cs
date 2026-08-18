using System;
using System.Numerics;
using AethericFlow.Config;
using AethericFlow.UI.Components;
using AethericFlow.Utility;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Interface.Windowing;

namespace AethericFlow.UI;

/// <summary>
/// The plugin window, holding the channel settings and the support page.
/// </summary>
public sealed class ConfigWindow : Window, IDisposable
{
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

        ImGui.TextWrapped(LocalisedText.SettingsIntro.Text);
        ImGui.Separator();

        if (ChatChannelSelector.Draw(configuration.EnabledChannels))
        {
            configuration.Save();
        }
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
