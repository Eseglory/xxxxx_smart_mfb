using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IStateRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StateRepository : DataRepositoryBase<State>, IStateRepository
    {
        public StateRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override State AddEntity(CoreContext entityContext, State entity)
        {
            return entityContext.Set<State>().Add(entity);
        }

        protected override State UpdateEntity(CoreContext entityContext, State entity)
        {
            return (from e in entityContext.Set<State>()
                    where e.StateId == entity.StateId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<State> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<State>()
                   select e;
        }

        protected override State GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<State>()
                         where e.StateId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<StateInfo> GetStates(string countryCode)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.StateSet
                            join b in entityContext.CountrySet on a.CountryCode equals b.Code
                            
                            where a.CountryCode == countryCode
                            select new StateInfo()
                            {
                                State = a,
                                Country = b
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
