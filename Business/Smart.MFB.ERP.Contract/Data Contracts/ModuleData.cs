using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Business.Core.Contract
{
    [DataContract]
    public class ModuleData : DataContractBase
    {
        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public long ModuleCategoryId { get; set; }

        [DataMember]
        public string ModuleCategoryAlias { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public bool TestMode { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
