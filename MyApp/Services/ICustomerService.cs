using System;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult<Customer>> GetCustomerAsync(string customerId);
        Task<ServiceCollectionResult<Customer>> ListAsync(string filter, int maxResults = 100);
        Task<ServiceResult> UpdateCustomer(UpdateCustomerRequest request);
    }
}
