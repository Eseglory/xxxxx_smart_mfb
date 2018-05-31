using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Client.Core.Contract
{
    [DataContract]
    public class MenuData : DataContractBase
    {
        [DataMember]
        public long MenuId { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string imageUrl { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
