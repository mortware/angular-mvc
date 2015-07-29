using System.Data.Entity.ModelConfiguration;
using MyApp.Data.Models;

namespace MyApp.Data.EF.EntityConfiguration
{
    internal class CustomerEntityTypeConfiguration : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerEntityTypeConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Customer");
        }
    }
}
