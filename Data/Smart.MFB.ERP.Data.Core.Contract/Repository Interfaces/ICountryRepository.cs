
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface ICountryRepository : IDataRepository<Country>
    {
        string GetCountryShortCode(string code);
    }
}
