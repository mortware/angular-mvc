using System.Data.Entity;
using System.Reflection;
using MyApp.DataAccess.Models;

namespace MyApp.DataAccess
{
    public class MyAppContext : DbContext
    {
        public IDbSet<UserEntity> Users { get; set; }

        public MyAppContext()
        {
            
        }

        public MyAppContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof (MyAppContext)));
        }
    }
}
