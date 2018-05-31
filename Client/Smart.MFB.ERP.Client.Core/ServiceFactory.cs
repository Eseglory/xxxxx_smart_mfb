using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core;
using System.ComponentModel.Composition;

namespace Smart.MFB.ERP.Client.Core
{
    [Export(typeof(IServiceFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServiceFactory : IServiceFactory
    {
        T IServiceFactory.CreateClient<T>()
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
