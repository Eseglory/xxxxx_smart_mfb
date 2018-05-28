using Smart.MFB.ERP.Common;
using Smart.MFB.ERP.Common.Contracts;

namespace Smart.MFB.ERP.Integration.AuditTrail
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, DataContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
