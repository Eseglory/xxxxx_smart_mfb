using Smart.MFB.ERP.Common.Core.Entities;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public class GroupRoleInfo
    {
        public GroupRole GroupRole { get; set; }
        public Group Group { get; set; }
        public Role Role { get; set; }
        public Module Module { get; set; }
    }
}