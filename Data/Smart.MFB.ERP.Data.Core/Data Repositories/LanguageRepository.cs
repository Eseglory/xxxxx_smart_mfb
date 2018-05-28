using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(ILanguageRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LanguageRepository : DataRepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Language AddEntity(CoreContext entityContext, Language entity)
        {
            return entityContext.Set<Language>().Add(entity);
        }

        protected override Language UpdateEntity(CoreContext entityContext, Language entity)
        {
            return (from e in entityContext.Set<Language>()
                    where e.LanguageId == entity.LanguageId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Language> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Language>()
                   select e;
        }

        protected override Language GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Language>()
                         where e.LanguageId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
