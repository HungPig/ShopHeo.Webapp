using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHeo.Application.System.User;
using ShopHeo.Application.System.Users;
using ShopHeo.ViewModels.CataLog.Users;
using System.Threading.Tasks;

namespace ShopHeo.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly IUserService userService;
        public UsersControllers(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await this.userService.Authencate(request);

            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken);
            }
            return Ok(new {token = resultToken });
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await this.userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
