using System;
using System.ComponentModel.Composition;
using System.Linq;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Common.Data
{
    [Export(typeof(IDataRepositoryFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
