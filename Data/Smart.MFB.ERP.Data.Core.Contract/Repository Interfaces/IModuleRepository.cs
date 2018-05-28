
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Data.Core.Contract
{
    public interface IModuleRepository : IDataRepository<Module>
    {
        IEnumerable<ModuleInfo> GetModules();
        void ActivateModule(long moduleId);
        void DeactivateModule(long moduleId);
    }
}
