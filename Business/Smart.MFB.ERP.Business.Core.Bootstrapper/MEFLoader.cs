using Smart.MFB.ERP.Common.Data;
using Smart.MFB.ERP.Data.Core;
using System.ComponentModel.Composition.Hosting;

namespace Smart.MFB.ERP.Business.Core.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleCategoryRepository).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DataRepositoryFactory).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }

    }
}
