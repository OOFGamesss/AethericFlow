using System;
using System.IO;
using System.Numerics;
using AethericFlow.Utility;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility;
using Dalamud.Utility;

namespace AethericFlow.UI.Components;

/// <summary>
/// Draws the support panel.
/// </summary>
public static class SupportPanel
{
    private const string DiscordUrl = "https://discord.gg/vM6ff4h5Ym";
    private const float LogoWidth = 160f;
    private const float StudioLogoWidth = 56f;

    private static readonly string ImageDirectory =
        Path.Combine(Plugin.PluginInterface.AssemblyLocation.DirectoryName ?? string.Empty, "Images");

    private static readonly string LogoPath = Path.Combine(ImageDirectory, "aethericflow.png");

    private static readonly string StudioLogoPath = Path.Combine(ImageDirectory, "oofgames.png");

    private static readonly (LocalisedString Question, LocalisedString Answer)[] Faq =
    [
        (LocalisedText.FaqUsageQuestion, LocalisedText.FaqUsageAnswer),
        (LocalisedText.FaqMissingQuestion, LocalisedText.FaqMissingAnswer),
        (LocalisedText.FaqSupportQuestion, LocalisedText.FaqSupportAnswer),
    ];

    public static void Draw()
    {
        DrawCentredImage(LogoPath, LogoWidth);
        ImGuiHelpers.ScaledDummy(6f);
        ImGui.Separator();
        ImGuiHelpers.ScaledDummy(8f);
        DrawFaq();
        DrawDiscordLink();
    }

    private static void DrawCentredImage(string path, float baseWidth)
    {
        var width = baseWidth * ImGuiHelpers.GlobalScale;
        var image = Plugin.TextureProvider.GetFromFile(path).GetWrapOrDefault();

        if (image == null || image.Width == 0)
        {
            CentreForWidth(width);
            ImGui.Dummy(new Vector2(width, width));
            return;
        }

        var size = new Vector2(width, width * image.Height / image.Width);
        CentreForWidth(size.X);
        ImGui.Image(image.Handle, size);
    }

    private static void DrawFaq()
    {
        for (var index = 0; index < Faq.Length; index++)
        {
            var (question, answer) = Faq[index];

            if (ImGui.CollapsingHeader($"{question.Text}###aethericFlowFaq{index}", ImGuiTreeNodeFlags.DefaultOpen))
            {
                ImGui.TextWrapped(answer.Text);
            }

            ImGuiHelpers.ScaledDummy(6f);
        }
    }

    private static void DrawDiscordLink()
    {
        var label = LocalisedText.DiscordButton.Text;
        var reserved = (StudioLogoWidth * ImGuiHelpers.GlobalScale) + ImGui.GetStyle().ItemSpacing.Y + ImGui.GetFrameHeight();
        var spare = ImGui.GetContentRegionAvail().Y - reserved;
        if (spare > 0f)
        {
            ImGui.Dummy(new Vector2(1f, spare));
        }

        DrawCentredImage(StudioLogoPath, StudioLogoWidth);

        CentreForWidth(ImGui.CalcTextSize(label).X + (ImGui.GetStyle().FramePadding.X * 2f));
        if (ImGui.Button(label))
        {
            Util.OpenLink(DiscordUrl);
        }
    }

    private static void CentreForWidth(float width)
    {
        var available = ImGui.GetContentRegionAvail().X;
        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + MathF.Max(0f, (available - width) * 0.5f));
    }
}
