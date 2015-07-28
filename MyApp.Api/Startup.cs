using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using MyApp.Api;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Startup))]

namespace MyApp.Api
{
    public partial class Startup
    {
        private static readonly IUnityContainer Container = UnityHelpers.GetConfiguredContainer();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var startup = Container.Resolve<Startup>();

            IDisposable webApp = WebApp.Start("http://localhost:8081", startup.Configuration);

            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            var webApiConfiguration = ConfigureWebApi();

            app.UseWebApi(webApiConfiguration);

            //UnityConfig.RegisterComponents();

            var config = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer())
            };
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "GET" }
            );
            return config;
        }


    }
}
