using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class ModuleCategory : EntityBase, IIdentifiableEntity
    {
        public ModuleCategory()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the ModuleCategoryId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long ModuleCategoryId { get; set; }

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
        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ModuleCategoryId; }
            set { ModuleCategoryId = value; }
        }

        #endregion
    }
}
