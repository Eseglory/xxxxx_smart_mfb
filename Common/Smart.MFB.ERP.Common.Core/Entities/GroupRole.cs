using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class GroupRole : EntityBase, IIdentifiableEntity
    {
        public GroupRole()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the GroupRoleId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long GroupRoleId { get; set; }

        [DataMember]
        [Required]
        public long GroupId { get; set; }

        [DataMember]
        [Required]
        public long RoleId { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return GroupRoleId; }
            set { GroupRoleId = value; }
        }

        #endregion
    }
}
