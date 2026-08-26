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

    public static LocalisedString WalkHint { get; } = new(
        "Quicker on foot",
        "徒歩の方が速いです",
        "Zu Fuß schneller",
        "Plus rapide à pied");

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

    public static LocalisedString SettingsGeneral { get; } = new(
        "General",
        "全般",
        "Allgemein",
        "Général");

    public static LocalisedString SettingsChannels { get; } = new(
        "Channels",
        "チャンネル",
        "Kanäle",
        "Canaux");

    public static LocalisedString SettingsAppearance { get; } = new(
        "Appearance",
        "外観",
        "Darstellung",
        "Apparence");

    public static LocalisedString LinkColourLabel { get; } = new(
        "Teleport link colour",
        "テレポリンクの色",
        "Farbe des Teleport-Links",
        "Couleur du lien de téléportation");

    public static LocalisedString WalkHintToggle { get; } = new(
        "Tell me when walking would be quicker",
        "歩いた方が速いときに知らせる",
        "Hinweis anzeigen, wenn Laufen schneller wäre",
        "M'indiquer quand la marche serait plus rapide");

    public static LocalisedString MapFlagToggle { get; } = new(
        "Place a map flag when I teleport",
        "テレポ時にマップにフラッグを立てる",
        "Beim Teleportieren eine Kartenmarkierung setzen",
        "Placer un drapeau sur la carte lors de la téléportation");

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
        "Map links posted on the channels you have enabled gain a teleport link beside them. Click it to travel, or use /aftp to reach the most recent one without touching your mouse. Teleporting drops a map flag on the destination, and the link tells you when you are closer to it than the aetheryte is.",
        "有効にしたチャンネルに投稿されたマップリンクには、テレポリンクが追加されます。クリックしてテレポするか、マウスを使わずに /aftp で最新のリンク先へ移動できます。テレポすると目的地にマップフラッグが立ち、エーテライトよりも自分の方が近い場合はリンクがそれを知らせます。",
        "Kartenlinks in den von dir aktivierten Kanälen erhalten daneben einen Teleport-Link. Klicke darauf, um zu reisen, oder nutze /aftp, um ohne Maus zum neuesten Link zu gelangen. Beim Teleportieren wird eine Kartenmarkierung am Ziel gesetzt, und der Link sagt dir, wenn du näher dran bist als der Ätheryt.",
        "Les liens de carte publiés sur les canaux que vous avez activés reçoivent un lien de téléportation. Cliquez dessus pour voyager, ou utilisez /aftp pour rejoindre le plus récent sans toucher à la souris. La téléportation place un drapeau sur la destination, et le lien vous prévient lorsque vous en êtes plus proche que l'éthérite.");

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
