using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalSolidario.Startup))]
namespace PortalSolidario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
