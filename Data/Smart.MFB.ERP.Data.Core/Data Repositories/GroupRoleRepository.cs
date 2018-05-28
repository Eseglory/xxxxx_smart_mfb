using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IGroupRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GroupRoleRepository : DataRepositoryBase<GroupRole>, IGroupRoleRepository
    {
        public GroupRoleRepository()
        {
            //_connection = DataConnectionEnum.Common;
        }

        protected override GroupRole AddEntity(CoreContext entityContext, GroupRole entity)
        {
            return entityContext.Set<GroupRole>().Add(entity);
        }

        protected override GroupRole UpdateEntity(CoreContext entityContext, GroupRole entity)
        {
            return (from e in entityContext.Set<GroupRole>()
                    where e.GroupRoleId == entity.GroupRoleId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<GroupRole> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<GroupRole>()
                   select e;
        }

        protected override GroupRole GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<GroupRole>()
                         where e.GroupRoleId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<GroupRoleInfo> GetGroupRoles(long groupId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.GroupRoleSet
                            join b in entityContext.GroupSet on a.GroupId equals b.GroupId
                            join c in entityContext.RoleSet on a.RoleId equals c.RoleId
                            join d in entityContext.ModuleSet on c.ModuleId equals d.ModuleId
                            where a.GroupId == groupId
                            select new GroupRoleInfo()
                            {
                                GroupRole = a,
                                Group = b,
                                Role = c,
                                Module = d
                            };

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<GroupRole> GetGroupRoleByLogin(string moduleName, string loginName, List<string> roleNames)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var groupQuery = from a in entityContext.GroupSet
                                 join b in entityContext.UserGroupSet on a.GroupId equals b.GroupId
                                 join c in entityContext.UserSet on b.UserId equals c.UserId
                                 where c.LoginID == loginName
                                 select a;

                var group = groupQuery.FirstOrDefault();

                var rolesQuery = from a in entityContext.GroupRoleSet
                                 join b in entityContext.RoleSet on a.RoleId equals b.RoleId
                                 join c in entityContext.ModuleSet on b.ModuleId equals c.ModuleId
                                 where c.Name == moduleName && roleNames.Contains(b.Name)
                                 select a;

                return rolesQuery.ToFullyLoaded();

            }
        }
    }
}
