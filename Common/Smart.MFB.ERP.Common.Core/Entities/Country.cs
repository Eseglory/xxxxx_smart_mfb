using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Country : EntityBase, IIdentifiableEntity
    {
        public Country()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the CountryId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long CountryId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        public string ShortCode { get; set; }



        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return CountryId; }
            set { CountryId = value; }
        }

        #endregion
    }
}
