using System.Data.Entity;
using System.Reflection;
using MyApp.Data.Models;

namespace MyApp.Data.EF
{
    public class MyAppContext : DbContext
    {
        public IDbSet<CustomerEntity> Customers { get; set; }

        public MyAppContext() { }
        public MyAppContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(MyAppContext)));
        }
    }
}
