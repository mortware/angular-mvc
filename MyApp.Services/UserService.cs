using System;
using System.Linq;
using System.Threading.Tasks;
using MyApp.DataAccess.Models;
using MyApp.Models;
using MyApp.Repository;
using Services;

namespace MyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<User>> GetUserAsync(string userId)
        {
            try
            {
                var entity = await _userRepository.GetAsync(userId);
                return ServiceResult<User>.Success(Map(entity));
            }
            catch (Exception ex)
            {
                return ServiceResult<User>.Failed(ex.Message);
            }
        }

        public async Task<ServiceCollectionResult<User>> ListAsync(string filter, int maxResults = 20)
        {
            try
            {
                var query = _userRepository.Query();
                
                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(x => x.DisplayName.Contains(filter)
                        || x.FirstName.Contains(filter)
                        || x.LastName.Contains(filter));
                }

                query = query
                    .Take(maxResults)
                    .OrderBy(x => x.DisplayName);

                var list = await _userRepository.GetAsync(query);
                return ServiceCollectionResult<User>.Success(list.Select(Map));
            }
            catch (Exception ex)
            {
                return ServiceCollectionResult<User>.Failed(ex.Message);
            }
        }

        private User Map(UserEntity entity)
        {
            var model = new User()
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth
            };
            return model;
        }
    }
}
