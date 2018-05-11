using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class MenuRole : EntityBase, IIdentifiableEntity
    {
        public MenuRole()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the MenuRoleId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long MenuRoleId { get; set; }

        [DataMember]
        [Required]
        public long MenuId { get; set; }

        [DataMember]
        [Required]
        public long RoleId { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return MenuRoleId; }
            set { MenuRoleId = value; }
        }

        #endregion
    }
}
