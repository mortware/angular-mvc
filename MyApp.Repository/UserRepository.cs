using MyApp.DataAccess.Models;

namespace MyApp.Repository
{
    public class UserRepository : RepositoryBase<UserEntity, string>, IUserRepository
    {
    }
}
