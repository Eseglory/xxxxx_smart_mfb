using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Host.Startup))]
namespace Host
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
