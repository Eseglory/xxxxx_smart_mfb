using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Client.Core.Contract
{
    [DataContract]
    public class UserGroupData : DataContractBase
    {
        [DataMember]
        public long UserGroupId { get; set; }

        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
