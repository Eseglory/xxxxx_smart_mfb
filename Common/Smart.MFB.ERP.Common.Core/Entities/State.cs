using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class State : EntityBase, IIdentifiableEntity
    {
        public State()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the StateId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long StateId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        [Required]
        public string CountryCode { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return StateId; }
            set { StateId = value; }
        }

        #endregion
    }
}
