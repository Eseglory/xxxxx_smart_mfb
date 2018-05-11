using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Religion : EntityBase, IIdentifiableEntity
    {
        public Religion()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the ReligionId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long ReligionId { get; set; }

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
            get { return ReligionId; }
            set { ReligionId = value; }
        }

        #endregion
    }
}
