using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class AddressType : EntityBase, IIdentifiableEntity
    {
        public AddressType()
        {
        }


        [DataMember]
        [Browsable(false)]
        public long AddressTypeId { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]

        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return AddressTypeId; }
            set { AddressTypeId = value; }
        }

        #endregion
    }
}
