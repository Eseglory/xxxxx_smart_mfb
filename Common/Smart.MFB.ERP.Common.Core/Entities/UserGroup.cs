using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class UserGroup : EntityBase, IIdentifiableEntity
    {
        public UserGroup()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the UserGroupId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long UserGroupId { get; set; }

        [DataMember]
        [Required]
        public long GroupId { get; set; }

        [DataMember]
        [Required]
        public long UserId { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return UserGroupId; }
            set { UserGroupId = value; }
        }

        #endregion
    }
}
