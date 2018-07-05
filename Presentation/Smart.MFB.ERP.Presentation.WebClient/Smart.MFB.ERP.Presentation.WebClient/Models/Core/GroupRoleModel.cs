using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class GroupRoleModel
    {
        public Group Group { get; set; }
        public GroupRoleData[] GroupRoles { get; set; }
    }
}