﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PortalSolidarioApi.Startup))]

namespace PortalSolidarioApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
