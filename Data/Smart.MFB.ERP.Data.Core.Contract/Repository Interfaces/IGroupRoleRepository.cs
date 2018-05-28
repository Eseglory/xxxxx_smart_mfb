
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IGroupRoleRepository : IDataRepository<GroupRole>
    {
        IEnumerable<GroupRoleInfo> GetGroupRoles(long groupId);

        IEnumerable<GroupRole> GetGroupRoleByLogin(string moduleName, string loginName, List<string> roleNames);
    }
}
