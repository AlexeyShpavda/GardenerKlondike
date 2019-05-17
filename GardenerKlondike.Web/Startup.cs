using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GardenerKlondike.Web.Startup))]
namespace GardenerKlondike.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
