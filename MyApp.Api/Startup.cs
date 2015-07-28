using Microsoft.Owin;
using MyApp.Api;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MyApp.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
