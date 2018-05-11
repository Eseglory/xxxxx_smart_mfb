using Smart.MFB.ERP.Common.Contracts;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class User : EntityBase, IIdentifiableEntity
    {
        public User()
        {
        }

        [DataMember]
        [Browsable(false)]
        public long UserId { get; set; }

        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }

        [DataMember]
        [Required]
        public string LoginID { get; set; }

        [DataMember]

        public string Email { get; set; }

        [DataMember]

        public string Mobile { get; set; }

        [DataMember]
        [Required]
        public EntityScopeEnum EntityScope { get; set; }

        [DataMember]
        [Required]
        public string ScopeCode { get; set; }

        [DataMember]
        [Required]
        public long GroupId { get; set; }

        [DataMember]
        [Required]
        public string ServiceProviderCode { get; set; }

        [DataMember]
        public DateTime LastLoginDate { get; set; }

        [DataMember]
        public bool IsLock { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return UserId; }
            set { UserId = value; }
        }

        #endregion
    }
}
