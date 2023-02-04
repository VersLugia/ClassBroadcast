using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace ClassBroadcast_NWApi
{
    public class Config
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Activation of debug mode")]
        public bool Debug { get; set; } = false;
        [Description("Available broadcast types: Broadcast, Hint, Window")]
        public SpawnInfoType SpawnInfoType { get; set; } = SpawnInfoType.Hint;
        public ushort SpawnInfoTime { get; set; } = 7;
        public Dictionary<RoleTypeId, string> SpawnInfoMessages { get; set; } = new Dictionary<RoleTypeId, string>
        {
            [RoleTypeId.FacilityGuard] = "<color=#727472>You will die in 5 minutes</color>",
            [RoleTypeId.Scp049] = "<color=#228B22>Doctor.</color>",
            [RoleTypeId.Scp173] = "<color=red>Matthew.</color>"
        };
    }
}