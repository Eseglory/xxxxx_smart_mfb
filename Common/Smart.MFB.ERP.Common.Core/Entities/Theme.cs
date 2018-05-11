using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Theme : EntityBase, IIdentifiableEntity
    {
        public Theme()
        {
        }

        [DataMember]
        [Browsable(false)]
        public long ThemeId { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        public bool Active { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return ThemeId; }
            set { ThemeId = value; }
        }

        #endregion
    }
}
