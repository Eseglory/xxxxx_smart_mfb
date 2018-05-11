using Smart.MFB.ERP.Common.Contracts;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    public partial class AuditTrail : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        [Browsable(false)]
        public long AuditTrailId { get; set; }

        [DataMember]
        [Required]
        public DateTime RevisionStamp { get; set; }

        [DataMember]
        [Required]
        public string TableName { get; set; }

        [DataMember]
        [Required]
        public string UserName { get; set; }

        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public AuditAction Actions { get; set; }

        [DataMember]
        public string ActionDescription { get; set; }

        [DataMember]
        public string OldData { get; set; }

        [DataMember]
        public string NewData { get; set; }

        [DataMember]
        public string ChangedColumns { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return AuditTrailId; }
            set { AuditTrailId = value; }
        }

        #endregion
    }
}
