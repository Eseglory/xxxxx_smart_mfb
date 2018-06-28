using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smart.MFB.ERP.Host.WService.Startup))]
namespace Smart.MFB.ERP.Host.WService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
