using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOSMaps.Startup))]
namespace DOSMaps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
