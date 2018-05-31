using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Client.Core.Contract
{
    [DataContract]
    public class RoleData : DataContractBase
    {
        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LongName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
