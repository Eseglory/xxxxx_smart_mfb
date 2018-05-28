using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IThemeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ThemeRepository : DataRepositoryBase<Theme>, IThemeRepository
    {
        public ThemeRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }

        protected override Theme AddEntity(CoreContext entityContext, Theme entity)
        {
            return entityContext.Set<Theme>().Add(entity);
        }

        protected override Theme UpdateEntity(CoreContext entityContext, Theme entity)
        {
            return (from e in entityContext.Set<Theme>()
                    where e.ThemeId == entity.ThemeId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Theme> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<Theme>()
                   select e;
        }

        protected override Theme GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<Theme>()
                         where e.ThemeId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

    }
}
