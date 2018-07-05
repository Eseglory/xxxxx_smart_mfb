using Smart.MFB.ERP.Common.Core;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using core = Smart.MFB.ERP.Client.Core.Bootstrapper;

namespace Smart.MFB.ERP.Presentation.WebClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            catalog.Catalogs.Add(core.MEFLoader.Init().Catalog);
            ObjectBase.Container = new CompositionContainer(catalog);

            DependencyResolver.SetResolver(new MefDependencyResolver(ObjectBase.Container)); // view controllers
            GlobalConfiguration.Configuration.DependencyResolver = new MefAPIDependencyResolver(ObjectBase.Container);
        }
    }
}
