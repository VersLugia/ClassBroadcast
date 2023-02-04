using System;
using Exiled.API.Features;

namespace ClassBroadcast
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "ClassBroadcast";
        public override string Author => "VersLugia";
        public override Version Version { get; } = new Version(1, 0, 0);
        public static Plugin Singleton { get; set; }
        private EventHandlers Events { get; set; }

        public override void OnEnabled()
        {
            Singleton = this;
            Events = new EventHandlers();
            Exiled.Events.Handlers.Player.ChangingRole += Events.OnChangingRole;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= Events.OnChangingRole;
            Singleton = null;
            Events = null;
            base.OnDisabled();
        }
    }
}