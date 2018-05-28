using Smart.MFB.ERP.Common.Core.Entities;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public class UserGroupInfo
    {
        public UserGroup UserGroup { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}