using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IAuditTrailRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AuditTrailRepository : DataRepositoryBase<AuditTrail>, IAuditTrailRepository
    {
        public AuditTrailRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override AuditTrail AddEntity(CoreContext entityContext, AuditTrail entity)
        {
            return entityContext.Set<AuditTrail>().Add(entity);
        }

        protected override AuditTrail UpdateEntity(CoreContext entityContext, AuditTrail entity)
        {
            return (from e in entityContext.Set<AuditTrail>()
                    where e.AuditTrailId == entity.AuditTrailId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<AuditTrail> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<AuditTrail>()
                   select e;
        }

        protected override AuditTrail GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<AuditTrail>()
                         where e.AuditTrailId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
