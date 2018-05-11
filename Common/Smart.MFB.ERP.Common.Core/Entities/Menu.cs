using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Menu : EntityBase, IIdentifiableEntity
    {
        public Menu()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the MenuId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long MenuId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        [Required]
        public string Alias { get; set; }

        [DataMember]
        [Required]
        public string Action { get; set; }

        [DataMember]
        public string Controller { get; set; }

        [DataMember]
        [Required]
        public long ModuleId { get; set; }

        [DataMember]
        public long? ParentId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return MenuId; }
            set { MenuId = value; }
        }

        #endregion
    }
}
