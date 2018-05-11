using Smart.MFB.ERP.Common.Contracts;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class ApplicantReg : EntityBase, IIdentifiableEntity
    {
        public ApplicantReg()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the ApplicantId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long ApplicantRegId { get; set; }

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
        public GenderEnumApp Gender { get; set; }

        [DataMember]
        [Required]
        public string ApplicantCode { get; set; }

        [DataMember]
        public DateTime LastLoginDate { get; set; }

        [DataMember]
        public bool IsLock { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ApplicantRegId; }
            set { ApplicantRegId = value; }
        }

        #endregion
    }
}
