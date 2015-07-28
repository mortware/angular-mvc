using MyApp.Data.Models;

namespace MyApp.Data.Repository
{
    public interface ICustomerRepository : IRepository<CustomerEntity, string>
    {
    }
}
