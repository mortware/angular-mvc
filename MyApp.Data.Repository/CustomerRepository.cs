using MyApp.Data.Models;

namespace MyApp.Data.Repository
{
    public class CustomerRepository : RepositoryBase<CustomerEntity, string>, ICustomerRepository
    {
    }
}
