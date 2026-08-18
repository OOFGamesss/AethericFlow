namespace AethericFlow.Utility;

/// <summary>
/// Every phrase the plugin shows the player, written out in each language.
/// </summary>
public static class LocalisedText
{
    public static LocalisedString TeleportLink { get; } = new(
        "Teleport to {0}",
        "{0} にテレポ",
        "Teleport zu {0}",
        "Téléportation vers {0}");

    public static LocalisedString NoMapLinkSeen { get; } = new(
        "No map link with a reachable aetheryte has been seen yet.",
        "テレポ可能なエーテライトを含むマップリンクはまだありません。",
        "Es wurde noch kein Kartenlink mit einem erreichbaren Ätheryten gefunden.",
        "Aucun lien de carte avec une éthérite accessible n'a encore été vu.");

    public static LocalisedString ConfigCommandHelp { get; } = new(
        "Opens the Aetheric Flow configuration window.",
        "Aetheric Flow の設定ウィンドウを開きます。",
        "Öffnet das Konfigurationsfenster von Aetheric Flow.",
        "Ouvre la fenêtre de configuration d'Aetheric Flow.");

    public static LocalisedString TeleportCommandHelp { get; } = new(
        "Teleports to the aetheryte from the most recent map link in chat.",
        "チャットの最新のマップリンクにあるエーテライトへテレポします。",
        "Teleportiert zum Ätheryten des neuesten Kartenlinks im Chat.",
        "Vous téléporte vers l'éthérite du dernier lien de carte du chat.");

    public static LocalisedString TeleportAliasHelp { get; } = new(
        "Alias for /aftp.",
        "/aftp の別名です。",
        "Alias für /aftp.",
        "Alias de /aftp.");

    public static LocalisedString SettingsTab { get; } = new("Settings", "設定", "Einstellungen", "Paramètres");

    public static LocalisedString SupportTab { get; } = new("Support", "サポート", "Support", "Assistance");

    public static LocalisedString SettingsIntro { get; } = new(
        "Choose which chat channels are scanned for map links.",
        "マップリンクを検出するチャットチャンネルを選択してください。",
        "Wähle aus, welche Chat-Kanäle nach Kartenlinks durchsucht werden.",
        "Choisissez les canaux de chat à analyser pour y trouver des liens de carte.");

    public static LocalisedString DiscordButton { get; } = new(
        "Join the OOF Games Discord",
        "OOF Games の Discord に参加",
        "Dem OOF Games Discord beitreten",
        "Rejoindre le Discord OOF Games");

    public static LocalisedString FaqUsageQuestion { get; } = new(
        "How do I use it?",
        "使い方は？",
        "Wie benutze ich es?",
        "Comment l'utiliser ?");

    public static LocalisedString FaqUsageAnswer { get; } = new(
        "Any map link posted on a channel you have enabled gains a teleport link beside it. Click that link to teleport, or use /aftp to teleport to the most recent one without touching your mouse.",
        "有効にしたチャンネルに投稿されたマップリンクには、テレポリンクが追加されます。そのリンクをクリックするか、マウスを使わずに /aftp で最新のリンク先へテレポできます。",
        "Jeder Kartenlink in einem aktivierten Kanal erhält daneben einen Teleport-Link. Klicke darauf, um zu teleportieren, oder nutze /aftp, um ohne Maus zum neuesten Link zu reisen.",
        "Tout lien de carte publié sur un canal activé reçoit un lien de téléportation. Cliquez dessus pour vous téléporter, ou utilisez /aftp pour rejoindre le plus récent sans toucher à la souris.");

    public static LocalisedString FaqMissingQuestion { get; } = new(
        "Why did a map link not get a teleport link?",
        "マップリンクにテレポリンクが付かないのはなぜ？",
        "Warum hat ein Kartenlink keinen Teleport-Link bekommen?",
        "Pourquoi un lien de carte n'a-t-il pas de lien de téléportation ?");

    public static LocalisedString FaqMissingAnswer { get; } = new(
        "Either that channel is switched off on the Settings tab, or the zone has no aetheryte you have attuned to yet.",
        "そのチャンネルが設定タブで無効になっているか、そのエリアに登録済みのエーテライトがない可能性があります。",
        "Entweder ist dieser Kanal im Reiter Einstellungen deaktiviert, oder das Gebiet hat keinen Ätheryten, bei dem du dich bereits angemeldet hast.",
        "Soit ce canal est désactivé dans l'onglet Paramètres, soit la zone ne contient aucune éthérite que vous avez déjà enregistrée.");

    public static LocalisedString FaqSupportQuestion { get; } = new(
        "How do I report a bug or request a feature?",
        "不具合の報告や機能のリクエストはどこで？",
        "Wie melde ich einen Fehler oder wünsche mir eine Funktion?",
        "Comment signaler un bug ou demander une fonctionnalité ?");

    public static LocalisedString FaqSupportAnswer { get; } = new(
        "Post in the OOF Games Discord and we will take a look.",
        "OOF Games の Discord に投稿していただければ確認します。",
        "Poste im OOF Games Discord und wir schauen es uns an.",
        "Publiez sur le Discord OOF Games et nous y jetterons un œil.");

    public static LocalisedString ChannelSay { get; } = new("Say", "Say", "Sagen", "Dire");

    public static LocalisedString ChannelYell { get; } = new("Yell", "Yell", "Rufen", "Interpeller");

    public static LocalisedString ChannelShout { get; } = new("Shout", "Shout", "Schreien", "Crier");

    public static LocalisedString ChannelTellIncoming { get; } = new(
        "Tell (incoming)",
        "Tell (受信)",
        "Flüstern (eingehend)",
        "Message privé (reçu)");

    public static LocalisedString ChannelTellOutgoing { get; } = new(
        "Tell (outgoing)",
        "Tell (送信)",
        "Flüstern (ausgehend)",
        "Message privé (envoyé)");

    public static LocalisedString ChannelParty { get; } = new("Party", "パーティ", "Gruppe", "Équipe");

    public static LocalisedString ChannelCrossParty { get; } = new(
        "Cross-world party",
        "クロスワールドパーティ",
        "Weltübergreifende Gruppe",
        "Équipe inter-mondes");

    public static LocalisedString ChannelAlliance { get; } = new("Alliance", "アライアンス", "Allianz", "Alliance");

    public static LocalisedString ChannelFreeCompany { get; } = new(
        "Free company",
        "フリーカンパニー",
        "Freie Gesellschaft",
        "Compagnie libre");

    public static LocalisedString ChannelPvpTeam { get; } = new("PvP team", "PvPチーム", "PvP-Team", "Équipe JcJ");

    public static LocalisedString ChannelNoviceNetwork { get; } = new(
        "Novice network",
        "ビギナーチャンネル",
        "Neulingsnetzwerk",
        "Réseau des novices");

    public static LocalisedString ChannelEcho { get; } = new("Echo", "エコー", "Echo", "Écho");

    public static LocalisedString ChannelLinkshell { get; } = new(
        "Linkshell",
        "リンクシェル",
        "Kontaktkreis",
        "Linkshell");

    public static LocalisedString ChannelCrossLinkshell { get; } = new(
        "Cross-world linkshell",
        "クロスワールドリンクシェル",
        "Weltübergreifender Kontaktkreis",
        "Linkshell inter-mondes");
}
