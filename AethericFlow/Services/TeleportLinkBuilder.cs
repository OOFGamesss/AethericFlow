using System.Collections.Generic;
using AethericFlow.GameData;
using AethericFlow.Utility;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace AethericFlow.Services;

/// <summary>
/// Appends the clickable teleport link that follows a map link in chat.
/// </summary>
public sealed class TeleportLinkBuilder(TeleportLinkRegistry registry)
{
    private const ushort LinkColour = 500;

    public SeString Append(SeString message, AetheryteLocation aetheryte)
    {
        return message.Append(BuildPayloads(aetheryte));
    }

    private IEnumerable<Payload> BuildPayloads(AetheryteLocation aetheryte)
    {
        return
        [
            new TextPayload(" "),
            new UIForegroundPayload(LinkColour),
            registry.PayloadFor(aetheryte.RowId),
            new IconPayload(BitmapFontIcon.Aetheryte),
            new TextPayload(LocalisedText.TeleportLink.Format(aetheryte.Name)),
            RawPayload.LinkTerminator,
            UIForegroundPayload.UIForegroundOff,
        ];
    }
}
