using MyApp.DataAccess.Models;

namespace MyApp.Repository
{
    public interface IUserRepository : IRepository<UserEntity, string>
    {
    }
}
