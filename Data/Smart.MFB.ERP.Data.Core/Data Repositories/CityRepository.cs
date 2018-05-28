using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(ICityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CityRepository : DataRepositoryBase<City>, ICityRepository
    {
        public CityRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override City AddEntity(CoreContext entityContext, City entity)
        {
            return entityContext.Set<City>().Add(entity);
        }

        protected override City UpdateEntity(CoreContext entityContext, City entity)
        {
            return (from e in entityContext.Set<City>()
                    where e.CityId == entity.CityId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<City> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<City>()
                   select e;
        }

        protected override City GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<City>()
                         where e.CityId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<CityInfo> GetCities(long stateId)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.CitySet
                            join b in entityContext.StateSet on a.StateCode equals b.Code
                            join c in entityContext.CountrySet on b.CountryCode equals c.Code

                            //where a.StateId == stateId
                            select new CityInfo()
                            {
                                City = a,
                                State = b,
                                Country = c
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
