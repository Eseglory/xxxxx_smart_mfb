using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Business.Core.Contract
{
    [DataContract]
    public class GroupRoleData : DataContractBase
    {
        [DataMember]
        public long GroupRoleId { get; set; }

        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
