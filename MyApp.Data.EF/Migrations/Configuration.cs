using System;
using System.Data.Entity.Migrations;
using System.Linq;
using MyApp.Data.Models;

namespace MyApp.Data.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyAppContext>
    {
        private int MaxCustomers = 100;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyAppContext context)
        {

            int currentCustomerCount = context.Customers.Count();
            if (currentCustomerCount < MaxCustomers)
            {
                for (int i = 0; i < MaxCustomers - currentCustomerCount; i++)
                {
                    var org = Mortware.DataFactory.NameGenerator.Organisation();
                    context.Customers.Add(new CustomerEntity()
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        DisplayName = org,
                    });
                }    
            }
        }
    }
}
