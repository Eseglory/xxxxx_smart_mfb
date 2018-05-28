using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IUserGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserGroupRepository : DataRepositoryBase<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override UserGroup AddEntity(CoreContext entityContext, UserGroup entity)
        {
            return entityContext.Set<UserGroup>().Add(entity);
        }

        protected override UserGroup UpdateEntity(CoreContext entityContext, UserGroup entity)
        {
            return (from e in entityContext.Set<UserGroup>()
                    where e.UserGroupId == entity.UserGroupId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<UserGroup> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<UserGroup>()
                   select e;
        }

        protected override UserGroup GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<UserGroup>()
                         where e.UserGroupId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<UserGroupInfo> GetUserGroups()
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.UserGroupSet
                            join b in entityContext.GroupSet on a.GroupId equals b.GroupId
                            join c in entityContext.UserSet on a.UserId equals c.UserId
                            
                            select new UserGroupInfo()
                            {
                                UserGroup = a,
                                Group = b,
                                User = c
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
