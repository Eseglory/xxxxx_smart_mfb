
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IRoleRepository : IDataRepository<Role>
    {
        IEnumerable<RoleInfo> GetRoles();
    }
}
