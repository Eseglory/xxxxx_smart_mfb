
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IMenuRoleRepository : IDataRepository<MenuRole>
    {
        IEnumerable<MenuRoleInfo> GetMenuRoles();
        IEnumerable<MenuRoleInfo> GetRoleMenus(long roleId);
    }
}
