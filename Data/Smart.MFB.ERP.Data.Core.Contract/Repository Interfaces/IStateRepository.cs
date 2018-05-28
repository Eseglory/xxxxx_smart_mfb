
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IStateRepository : IDataRepository<State>
    {
        IEnumerable<StateInfo> GetStates(string countryCode);
    }
}
