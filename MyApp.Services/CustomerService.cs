using System;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Data.Models;
using MyApp.Data.Repository;
using MyApp.Models;

namespace MyApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _userRepository;

        public CustomerService(ICustomerRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceCollectionResult<Customer>> ListAsync(string filter, int maxResults = 20)
        {
            try
            {
                var query = _userRepository.Query();
                
                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(x => x.DisplayName.Contains(filter));
                }

                query = query
                    .Take(maxResults)
                    .OrderBy(x => x.DisplayName);

                var list = await _userRepository.GetAsync(query);
                return ServiceCollectionResult<Customer>.Success(list.Select(Map));
            }
            catch (Exception ex)
            {
                return ServiceCollectionResult<Customer>.Failed(ex.Message);
            }
        }

        public async Task<ServiceResult<Customer>> GetCustomerAsync(string customerId)
        {
            try
            {
                var entity = await _userRepository.GetAsync(customerId);
                return ServiceResult<Customer>.Success(Map(entity));
            }
            catch (Exception ex)
            {
                return ServiceResult<Customer>.Failed(ex.Message);
            }
        }

        public async Task<ServiceResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            try
            {
                CustomerEntity entity = await _userRepository.GetAsync(request.CustomerId);

                entity.DisplayName = request.DisplayName;
                await _userRepository.UpdateAsync(entity);

                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }

        private Customer Map(CustomerEntity entity)
        {
            var model = new Customer
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName
            };
            return model;
        }
    }
}
