 using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace ClassBroadcast_NWApi
{
    class EventHandlers
    {
        [PluginEvent(ServerEventType.PlayerChangeRole)]
        private void OnPlayerChangeRole(Player player, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
        {
            if (Plugin.Singleton.Config.SpawnInfoMessages.TryGetValue(newRole, out string message))
            {
                Timing.CallDelayed(1f, () =>
                {
                    switch (Plugin.Singleton.Config.SpawnInfoType)
                    {
                        default:
                        case SpawnInfoType.Broadcast:
                            player.SendBroadcast(message, Plugin.Singleton.Config.SpawnInfoTime, Broadcast.BroadcastFlags.Normal, true);
                            break;
                        case SpawnInfoType.Hint:
                            player.ReceiveHint(message, Plugin.Singleton.Config.SpawnInfoTime);
                            break;
                        case SpawnInfoType.Window:
                            player.SendConsoleMessage($"[REPORTING] {message}", "white");
                            break;
                    }
                    Log.Debug($"[{player.Nickname}] received [{newRole}] Spawn Broadcast", Plugin.Singleton.Config.Debug);
                });
            }
        }
    }
}