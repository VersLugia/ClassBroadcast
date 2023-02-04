using PluginAPI.Core.Attributes;
using PluginAPI.Events;

namespace ClassBroadcast_NWApi
{
    public class Plugin
    {
        public static Plugin Singleton { get; private set; }
        [PluginConfig] public Config Config;

        [PluginEntryPoint("ClassBroadcast", "1.0.0",
            "Sends configurable messages to players at spawn.",
            "VersLugia (original exiled version by An4r3w)")]
        void OnLoad()
        {
            if (!Config.IsEnabled)
                return;

            Singleton = this;
            EventManager.RegisterEvents<EventHandlers>(this);
        }

        [PluginUnload]
        void OnUnload()
        {
            Singleton = null;
            EventManager.UnregisterEvents<EventHandlers>(this);
        }
    }
}