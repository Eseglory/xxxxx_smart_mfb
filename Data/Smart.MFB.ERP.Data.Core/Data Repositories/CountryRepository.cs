using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(ICountryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryRepository : DataRepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository()
        {
            //_connection = DataConnectionEnum.Common;
        }

        protected override Country AddEntity(CoreContext entityContext, Country entity)
        {
            return entityContext.Set<Country>().Add(entity);
        }

        protected override Country UpdateEntity(CoreContext entityContext, Country entity)
        {
            return (from e in entityContext.Set<Country>()
                    where e.CountryId == entity.CountryId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Country> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Country>()
                   select e;
        }

        protected override Country GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Country>()
                         where e.CountryId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public string GetCountryShortCode(string code)
        {

            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.CountrySet
                            where a.Code == code
                            select a.ShortCode;

                return query.FirstOrDefault();
            }
        }
    }
}
