using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03_PortalMVC.Startup))]
namespace _03_PortalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
