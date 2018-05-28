using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Business.Core.Contract
{
    [DataContract]
    public class CityData : DataContractBase
    {
        [DataMember]
        public long CityId { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long StateId { get; set; }

        [DataMember]
        public string StateCode { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public long CountryId { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
