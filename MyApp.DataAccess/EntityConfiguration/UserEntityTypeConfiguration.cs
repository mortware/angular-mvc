using System.Data.Entity.ModelConfiguration;
using MyApp.DataAccess.Models;

namespace MyApp.DataAccess.EntityConfiguration
{
    internal class UserEntityTypeConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.ToTable("User");
        }
    }
}
