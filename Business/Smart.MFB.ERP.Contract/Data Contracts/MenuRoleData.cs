using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Business.Core.Contract
{
    [DataContract]
    public class MenuRoleData : DataContractBase
    {
        [DataMember]
        public long MenuRoleId { get; set; }

        [DataMember]
        public long MenuId { get; set; }

        [DataMember]
        public string MenuCode { get; set; }

        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public string LongName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
