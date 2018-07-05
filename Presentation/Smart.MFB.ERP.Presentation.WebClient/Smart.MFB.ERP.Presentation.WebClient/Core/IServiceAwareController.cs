using Smart.MFB.ERP.Common.Contracts;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Core
{
    public interface IServiceAwareController
    {
        void RegisterDisposableServices(List<IServiceContract> disposableServices);

        List<IServiceContract> DisposableServices { get; }
    }
}
