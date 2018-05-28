using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IModuleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleRepository : DataRepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Module AddEntity(CoreContext entityContext, Module entity)
        {
            return entityContext.Set<Module>().Add(entity);
        }

        protected override Module UpdateEntity(CoreContext entityContext, Module entity)
        {
            return (from e in entityContext.Set<Module>()
                    where e.ModuleId == entity.ModuleId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Module> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Module>()
                   select e;
        }

        protected override Module GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Module>()
                         where e.ModuleId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<ModuleInfo> GetModules()
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.ModuleSet
                            join b in entityContext.ModuleCategorySet on a.ModuleCategoryId equals b.ModuleCategoryId
                         
                            select new ModuleInfo()
                            {
                                Module = a,
                                ModuleCategory = b
                            };

                return query.ToFullyLoaded();
            }
        }

        public void ActivateModule(long moduleId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = (from a in entityContext.ModuleSet
                            where a.ModuleId == moduleId
                            select a).FirstOrDefault();
                query.Active = true;
                entityContext.SaveChanges();
            }
        }

        public void DeactivateModule(long moduleId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = (from a in entityContext.ModuleSet
                             where a.ModuleId == moduleId
                             select a).FirstOrDefault();
                query.Active = false;
                entityContext.SaveChanges();
            }
        }
    }
}
