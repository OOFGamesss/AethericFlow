using System;
using System.Collections.Generic;
using System.Linq;
using AethericFlow.Utility;
using Dalamud.Configuration;
using Dalamud.Game.Text;

namespace AethericFlow.Config;

/// <summary>
/// Persisted plugin settings, covering the chat channels, quicker on foot check, map flag placement,
/// icon only display and text link colours.
/// </summary>
[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    public HashSet<XivChatType> EnabledChannels { get; set; } =
        ChatChannelCatalogue.All.Select(channel => channel.Type).ToHashSet();

    public ushort LinkColour { get; set; } = 500;

    public bool ShowWalkHint { get; set; } = true;

    public bool PlaceMapFlag { get; set; } = true;

    public bool ShowTeleportIconOnly { get; set; } = false;

    public bool ShowClockIconOnly { get; set; } = false;

    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
