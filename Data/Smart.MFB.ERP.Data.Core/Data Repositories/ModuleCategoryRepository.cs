using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IModuleCategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleCategoryRepository : DataRepositoryBase<ModuleCategory>, IModuleCategoryRepository
    {
        public ModuleCategoryRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override ModuleCategory AddEntity(CoreContext entityContext, ModuleCategory entity)
        {
            return entityContext.Set<ModuleCategory>().Add(entity);
        }

        protected override ModuleCategory UpdateEntity(CoreContext entityContext, ModuleCategory entity)
        {
            return (from e in entityContext.Set<ModuleCategory>()
                    where e.ModuleCategoryId == entity.ModuleCategoryId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ModuleCategory> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<ModuleCategory>()
                   select e;
        }

        protected override ModuleCategory GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<ModuleCategory>()
                         where e.ModuleCategoryId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
