using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Microsoft.Practices.Unity;
using MyApp.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Startup))]
namespace MyApp.Api
{
    public class Startup
    {
        private static readonly IUnityContainer Container = UnityHelpers.GetConfiguredContainer();

        public static void StartServer(string baseUrl)
        {
            var startup = Container.Resolve<Startup>();
            WebApp.Start(baseUrl, startup.Configuration);
        }

        public void Configuration(IAppBuilder app)
        {
            // Override where the |DataDirectory| is, as OWIN will run the app from the bin folder
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../App_Data"));

            // Configure dependency injection for controllers
            var config = new HttpConfiguration { DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer()) };

            ConfigureWebApi(config);

            // Host the client application
            var options = new FileServerOptions { EnableDefaultFiles = true };
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            options.DefaultFilesOptions.FileSystem = new PhysicalFileSystem(@"..\..\MyApp.Web");
            options.DefaultFilesOptions.RequestPath = PathString.Empty;
            app.UseFileServer(options);

            app.UseWebApi(config);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            // Configure the only route to handle /api/{controller}/{action} requests
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "GET" }
            );

            // Configure all data to be sent and interpreted in a standard format
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

        }
    }
}
