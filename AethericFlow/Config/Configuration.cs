using System;
using System.Collections.Generic;
using System.Linq;
using AethericFlow.Utility;
using Dalamud.Configuration;
using Dalamud.Game.Text;

namespace AethericFlow.Config;

/// <summary>
/// Persisted plugin settings, currently just the set of chat channels that are scanned for map links.
/// </summary>
[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    public HashSet<XivChatType> EnabledChannels { get; set; } =
        ChatChannelCatalogue.All.Select(channel => channel.Type).ToHashSet();

    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
