using System;
using System.Threading.Tasks;
using MyApp.Models;
using Services;

namespace MyApp.Services
{
    public interface IUserService
    {
        Task<ServiceResult<User>> GetUserAsync(string userId);
        Task<ServiceCollectionResult<User>> ListAsync(string filter, int maxResults = 100);
    }
}
