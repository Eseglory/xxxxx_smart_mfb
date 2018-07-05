using Smart.MFB.ERP.Common.Core;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using core = Smart.MFB.ERP.Business.Core;

namespace Smart.MFB.ERP.Hosts.ServicePortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            #region Catalog
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(core.Bootstrapper.MEFLoader.Init().Catalog);
            ObjectBase.Container = new CompositionContainer(catalog);
            #endregion

            #region
            new core.CoreManager().RegisterModule();
            new core.CoreManager().RegisterReportModule();
            #endregion

        }
    }
}
