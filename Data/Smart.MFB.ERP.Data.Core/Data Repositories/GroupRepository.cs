using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GroupRepository : DataRepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Group AddEntity(CoreContext entityContext, Group entity)
        {
            return entityContext.Set<Group>().Add(entity);
        }

        protected override Group UpdateEntity(CoreContext entityContext, Group entity)
        {
            return (from e in entityContext.Set<Group>()
                    where e.GroupId == entity.GroupId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Group> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Group>()
                   select e;
        }

        protected override Group GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Group>()
                         where e.GroupId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
