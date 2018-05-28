using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IMenuRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuRoleRepository : DataRepositoryBase<MenuRole>, IMenuRoleRepository
    {
        public MenuRoleRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override MenuRole AddEntity(CoreContext entityContext, MenuRole entity)
        {
            return entityContext.Set<MenuRole>().Add(entity);
        }

        protected override MenuRole UpdateEntity(CoreContext entityContext, MenuRole entity)
        {
            return (from e in entityContext.Set<MenuRole>()
                    where e.MenuRoleId == entity.MenuRoleId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<MenuRole> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<MenuRole>()
                   select e;
        }

        protected override MenuRole GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<MenuRole>()
                         where e.MenuRoleId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<MenuRoleInfo> GetMenuRoles()
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.MenuRoleSet
                            join b in entityContext.MenuSet on a.MenuId equals b.MenuId
                            join c in entityContext.RoleSet on a.RoleId equals c.RoleId
                            join d in entityContext.ModuleSet on b.ModuleId equals d.ModuleId

                            select new MenuRoleInfo()
                            {
                                MenuRole = a,
                                Menu = b,
                                Role = c,
                                Module = d
                            };

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<MenuRoleInfo> GetRoleMenus(long roleId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.MenuRoleSet
                            join b in entityContext.MenuSet on a.MenuId equals b.MenuId
                            join c in entityContext.RoleSet on a.RoleId equals c.RoleId
                            join d in entityContext.ModuleSet on b.ModuleId equals d.ModuleId

                            where a.RoleId == roleId && b.Action != "None"
                            select new MenuRoleInfo()
                            {
                                MenuRole = a,
                                Menu = b,
                                Role = c,
                                Module = d
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
