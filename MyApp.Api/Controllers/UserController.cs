using System;
using System.Threading.Tasks;
using System.Web.Http;
using MyApp.Services;

namespace MyApp.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            var result = await _userService.GetUserAsync(userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> List(string filter = "", int max = 20)
        {
            var result = await _userService.ListAsync(filter, max);
            return Ok(result);
        }
   }
}
