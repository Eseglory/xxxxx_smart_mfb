using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class City : EntityBase, IIdentifiableEntity
    {
        public City()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the CityId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long CityId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        [Required]
        public string StateCode { get; set; }

        [DataMember]
        [Required]
        public long StateId { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return CityId; }
            set { CityId = value; }
        }

        #endregion
    }
}
