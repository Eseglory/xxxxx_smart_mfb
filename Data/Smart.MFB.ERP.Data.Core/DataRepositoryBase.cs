using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common;
using Smart.MFB.ERP.Data.Core;

namespace Smart.MFB.ERP.Data.Core
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, CoreContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
