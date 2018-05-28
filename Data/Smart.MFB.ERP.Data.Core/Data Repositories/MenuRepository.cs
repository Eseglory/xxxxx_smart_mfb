using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IMenuRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuRepository : DataRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }
        
        protected override Menu AddEntity(CoreContext entityContext, Menu entity)
        {
            return entityContext.Set<Menu>().Add(entity);
        }

        protected override Menu UpdateEntity(CoreContext entityContext, Menu entity)
        {
            return (from e in entityContext.Set<Menu>()
                    where e.MenuId == entity.MenuId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Menu> GetEntities(CoreContext entityContext)
        {
            
            return from e in entityContext.Set<Menu>()
                   select e;
        }

        protected override Menu GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Menu>()
                         where e.MenuId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<MenuInfo> GetModuleMenus(long moduleId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.MenuSet
                            join b in entityContext.ModuleSet on a.ModuleId equals b.ModuleId

                            where a.ModuleId == moduleId && a.Action != "None"

                            select new MenuInfo()
                            {
                                Menu = a,
                                Module = b
                            };

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<Menu> GetMenuByLogin(string LoginUser)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var groupQuery = from a in entityContext.GroupSet
                                 join b in entityContext.UserGroupSet on a.GroupId equals b.GroupId
                                 join c in entityContext.UserSet on b.UserId equals c.UserId
                                 where c.LoginID == LoginUser
                                 select a;

                var group = groupQuery.FirstOrDefault();
                
                long groupId = 0;

                if (group != null)
                    groupId = group.GroupId;

                var rolesQuery = from a in entityContext.GroupRoleSet
                                 join b in entityContext.RoleSet on a.RoleId equals b.RoleId
                                 

                                 where a.GroupId == groupId
                                 select b;

                var roleIds = rolesQuery.Select(c => c.RoleId).Distinct();


                var menusQuery = from a in entityContext.MenuRoleSet
                                 join b in entityContext.RoleSet on a.RoleId equals b.RoleId
                                 join c in entityContext.MenuSet on a.MenuId equals c.MenuId

                                 where roleIds.Contains(a.RoleId)
                                 select c;

                return menusQuery.ToFullyLoaded();

            }
        }
    }
}
