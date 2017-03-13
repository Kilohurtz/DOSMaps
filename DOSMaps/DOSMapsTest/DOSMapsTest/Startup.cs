using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOSMapsTest.Startup))]
namespace DOSMapsTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
