using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Role : EntityBase, IIdentifiableEntity
    {
        public Role()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the RoleId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long RoleId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public long ModuleId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return RoleId; }
            set { RoleId = value; }
        }

        #endregion
    }
}
