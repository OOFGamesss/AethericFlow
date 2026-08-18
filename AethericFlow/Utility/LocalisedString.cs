using Dalamud.Game;

namespace AethericFlow.Utility;

/// <summary>
/// One phrase in each language, resolved against the player's language.
/// </summary>
public readonly record struct LocalisedString(string English, string Japanese, string German, string French)
{
    public string Text => Plugin.DataManager.Language switch
    {
        ClientLanguage.Japanese => Japanese,
        ClientLanguage.German => German,
        ClientLanguage.French => French,
        _ => English,
    };

    public string Format(params object?[] values)
    {
        return string.Format(Text, values);
    }

    public LocalisedString Numbered(int number)
    {
        return new LocalisedString($"{English} {number}", $"{Japanese}{number}", $"{German} {number}", $"{French} {number}");
    }
}
