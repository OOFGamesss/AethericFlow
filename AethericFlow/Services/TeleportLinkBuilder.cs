using System.Collections.Generic;
using AethericFlow.Config;
using AethericFlow.GameData;
using AethericFlow.Utility;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace AethericFlow.Services;

/// <summary>
/// Appends the clickable teleport link that follows a map link in chat.
/// </summary>
public sealed class TeleportLinkBuilder(TeleportLinkRegistry registry, Configuration configuration)
{
    private const ushort HintColour = 3;

    public SeString Append(SeString message, AetheryteLocation aetheryte, MapLinkPayload mapLink, bool closerOnFoot)
    {
        message = message.Append(BuildPayloads(aetheryte, mapLink));

        return closerOnFoot ? message.Append(BuildHintPayloads()) : message;
    }

    private IEnumerable<Payload> BuildHintPayloads()
    {
        List<Payload> payloads =
        [
            new UIForegroundPayload(HintColour),
            new TextPayload($" {(char)SeIconChar.Clock}"),
        ];

        if (!configuration.ShowClockIconOnly)
        {
            payloads.Add(new TextPayload($" {LocalisedText.WalkHint.Text}"));
        }

        payloads.Add(UIForegroundPayload.UIForegroundOff);

        return payloads;
    }

    private IEnumerable<Payload> BuildPayloads(AetheryteLocation aetheryte, MapLinkPayload mapLink)
    {
        List<Payload> payloads =
        [
            new TextPayload(" "),
            new UIForegroundPayload(configuration.LinkColour),
            registry.PayloadFor(aetheryte, mapLink),
            new IconPayload(BitmapFontIcon.Aetheryte),
        ];

        if (!configuration.ShowTeleportIconOnly)
        {
            payloads.Add(new TextPayload(LocalisedText.TeleportLink.Format(aetheryte.Name)));
        }

        payloads.Add(RawPayload.LinkTerminator);
        payloads.Add(UIForegroundPayload.UIForegroundOff);

        return payloads;
    }
}
