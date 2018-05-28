
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IUserGroupRepository : IDataRepository<UserGroup>
    {
        IEnumerable<UserGroupInfo> GetUserGroups();
    }
}
