using System.Collections.Generic;
using System.Linq;
using Dalamud.Game.Text;

namespace AethericFlow.Utility;

/// <summary>
/// The chat channels Aetheric Flow is able to scan, paired with the labels shown in the configuration window.
/// </summary>
public static class ChatChannelCatalogue
{
    private static readonly XivChatType[] Linkshells =
    [
        XivChatType.Ls1, XivChatType.Ls2, XivChatType.Ls3, XivChatType.Ls4,
        XivChatType.Ls5, XivChatType.Ls6, XivChatType.Ls7, XivChatType.Ls8,
    ];

    private static readonly XivChatType[] CrossLinkshells =
    [
        XivChatType.CrossLinkShell1, XivChatType.CrossLinkShell2, XivChatType.CrossLinkShell3, XivChatType.CrossLinkShell4,
        XivChatType.CrossLinkShell5, XivChatType.CrossLinkShell6, XivChatType.CrossLinkShell7, XivChatType.CrossLinkShell8,
    ];

    public static IReadOnlyList<(XivChatType Type, LocalisedString Label)> All { get; } = Build();

    private static List<(XivChatType Type, LocalisedString Label)> Build()
    {
        List<(XivChatType Type, LocalisedString Label)> channels =
        [
            (XivChatType.Say, LocalisedText.ChannelSay),
            (XivChatType.Yell, LocalisedText.ChannelYell),
            (XivChatType.Shout, LocalisedText.ChannelShout),
            (XivChatType.TellIncoming, LocalisedText.ChannelTellIncoming),
            (XivChatType.TellOutgoing, LocalisedText.ChannelTellOutgoing),
            (XivChatType.Party, LocalisedText.ChannelParty),
            (XivChatType.CrossParty, LocalisedText.ChannelCrossParty),
            (XivChatType.Alliance, LocalisedText.ChannelAlliance),
            (XivChatType.FreeCompany, LocalisedText.ChannelFreeCompany),
            (XivChatType.PvPTeam, LocalisedText.ChannelPvpTeam),
            (XivChatType.NoviceNetwork, LocalisedText.ChannelNoviceNetwork),
            (XivChatType.Echo, LocalisedText.ChannelEcho),
        ];

        channels.AddRange(Numbered(Linkshells, LocalisedText.ChannelLinkshell));
        channels.AddRange(Numbered(CrossLinkshells, LocalisedText.ChannelCrossLinkshell));

        return channels;
    }

    private static IEnumerable<(XivChatType Type, LocalisedString Label)> Numbered(XivChatType[] types, LocalisedString basis)
    {
        return types.Select((type, index) => (type, basis.Numbered(index + 1)));
    }
}
