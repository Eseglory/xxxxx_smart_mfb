using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class RoleModel
    {
        public Role Role { get; set; }
        public MenuRoleData[] RoleMenus { get; set; }
    }
}