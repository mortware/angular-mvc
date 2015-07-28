using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity;
using MyApp.Data.Repository;
using MyApp.Services;

namespace MyApp.Api
{
    public static class UnityHelpers
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        public static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                    {
                        yield return type;
                    }
                }
            }
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Registers the full stack of dependencies
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType(typeof(Startup));
        }

    }
}