using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IReligionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReligionRepository : DataRepositoryBase<Religion>, IReligionRepository
    {
        public ReligionRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Religion AddEntity(CoreContext entityContext, Religion entity)
        {
            return entityContext.Set<Religion>().Add(entity);
        }

        protected override Religion UpdateEntity(CoreContext entityContext, Religion entity)
        {
            return (from e in entityContext.Set<Religion>()
                    where e.ReligionId == entity.ReligionId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Religion> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Religion>()
                   select e;
        }

        protected override Religion GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Religion>()
                         where e.ReligionId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
