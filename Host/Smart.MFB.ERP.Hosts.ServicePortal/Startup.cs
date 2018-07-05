using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smart.MFB.ERP.Hosts.ServicePortal.Startup))]
namespace Smart.MFB.ERP.Hosts.ServicePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
