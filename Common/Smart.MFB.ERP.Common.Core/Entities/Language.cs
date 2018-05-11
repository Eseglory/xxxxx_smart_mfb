using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Language : EntityBase, IIdentifiableEntity
    {
        public Language()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the LanguageId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long LanguageId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return LanguageId; }
            set { LanguageId = value; }
        }

        #endregion
    }
}
