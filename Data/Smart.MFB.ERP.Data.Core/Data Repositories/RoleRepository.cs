using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleRepository : DataRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Role AddEntity(CoreContext entityContext, Role entity)
        {
            return entityContext.Set<Role>().Add(entity);
        }

        protected override Role UpdateEntity(CoreContext entityContext, Role entity)
        {
            return (from e in entityContext.Set<Role>()
                    where e.RoleId == entity.RoleId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Role> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Role>()
                   select e;
        }

        protected override Role GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Role>()
                         where e.RoleId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<RoleInfo> GetRoles()
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.RoleSet
                            join b in entityContext.ModuleSet on a.ModuleId equals b.ModuleId

                            select new RoleInfo()
                            {
                                Role = a,
                                Module = b
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
