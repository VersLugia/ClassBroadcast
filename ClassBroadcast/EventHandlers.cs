using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace ClassBroadcast
{
    class EventHandlers
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (Plugin.Singleton.Config.SpawnInfoMessages.TryGetValue(ev.NewRole, out string message))
            {
                Timing.CallDelayed(1f, () =>
                {
                    switch (Plugin.Singleton.Config.SpawnInfoType)
                    {
                        default:
                        case SpawnInfoType.Broadcast:
                            ev.Player.Broadcast(Plugin.Singleton.Config.SpawnInfoTime, message, Broadcast.BroadcastFlags.Normal,true);
                           break;
                        case SpawnInfoType.Hint:
                            ev.Player.ShowHint(message, Plugin.Singleton.Config.SpawnInfoTime);
                            break;
                        case SpawnInfoType.Window:
                            ev.Player.OpenReportWindow(message);
                            break;
                    }
                    Log.Debug($"[{ev.Player.Nickname}] received [{ev.NewRole}] Spawn Broadcast");
                });
            }
        }
    }
}