using Microsoft.Practices.Unity;
using System.Web.Http;
using MyApp.Repository;
using MyApp.Services;
using Unity.WebApi;

namespace MyApp.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}