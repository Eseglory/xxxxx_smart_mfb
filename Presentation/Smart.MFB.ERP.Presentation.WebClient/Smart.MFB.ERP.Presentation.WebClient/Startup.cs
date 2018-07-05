using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Smart.MFB.ERP.Presentation.WebClient.Startup))]

namespace Smart.MFB.ERP.Presentation.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
