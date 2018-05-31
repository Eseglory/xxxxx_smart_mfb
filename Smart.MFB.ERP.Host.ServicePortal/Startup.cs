using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smart.MFB.ERP.Host.ServicePortal.Startup))]
namespace Smart.MFB.ERP.Host.ServicePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
