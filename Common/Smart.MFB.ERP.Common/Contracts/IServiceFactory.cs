using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart.MFB.ERP.Common.Contracts
{
    public interface IServiceFactory
    {
        T CreateClient<T>() where T : IServiceContract;
    }
}