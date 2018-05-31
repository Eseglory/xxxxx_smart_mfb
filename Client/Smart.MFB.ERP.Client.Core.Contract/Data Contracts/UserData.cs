using System.Runtime.Serialization;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Client.Core.Contract
{
    [DataContract]
    public class UserData : DataContractBase
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public string LoginId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Facebook { get; set; }

        [DataMember]
        public string Skype { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
