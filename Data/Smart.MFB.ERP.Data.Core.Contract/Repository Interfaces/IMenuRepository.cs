
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IMenuRepository : IDataRepository<Menu>
    {
        IEnumerable<MenuInfo> GetModuleMenus(long moduleId);
        IEnumerable<Menu> GetMenuByLogin(string LoginUser);
    }
}
