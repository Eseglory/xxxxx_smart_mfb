using Smart.MFB.ERP.Common.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Smart.MFB.ERP.Common.Core.Entities
{
    [DataContract]
    public partial class Group : EntityBase, IIdentifiableEntity
    {
        public Group()
        {
        }

        /// <summary>
        /// Gets or sets a long value for the GroupId column.
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public long GroupId { get; set; }

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
            get { return GroupId; }
            set { GroupId = value; }
        }

        #endregion
    }
}
