using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Smart.MFB.ERP.Prensentation.Startup))]
namespace Smart.MFB.ERP.Prensentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
