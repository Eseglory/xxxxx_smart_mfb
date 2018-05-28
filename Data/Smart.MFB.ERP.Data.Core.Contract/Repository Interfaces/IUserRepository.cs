
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IUserRepository : IDataRepository<User>
    {
        User GetByLogin(string loginID);
        IEnumerable<UserInfo> GetAllUser();
    }
}
