using System.Threading.Tasks;
using System.Web.Http;
using MyApp.Services;

namespace MyApp.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> List(string filter = "", int max = 20)
        {
            var result = await _customerService.ListAsync(filter, max);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomer(string customerId)
        {
            var result = await _customerService.GetCustomerAsync(customerId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
            var result = await _customerService.UpdateCustomer(request);
            return Ok(result);
        }
   }
}
