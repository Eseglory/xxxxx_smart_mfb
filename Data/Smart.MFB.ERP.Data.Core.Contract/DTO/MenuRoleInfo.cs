using Smart.MFB.ERP.Common.Core.Entities;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public class MenuRoleInfo
    {
        public MenuRole MenuRole { get; set; }
        public Menu Menu { get; set; }
        public Role Role { get; set; }
        public Module Module { get; set; }
    }
}