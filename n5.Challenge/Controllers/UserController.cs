using Microsoft.AspNetCore.Mvc;
using n5.Challenge.Application;

namespace n5.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserManager userManager) : ControllerBase
    {
        private readonly IUserManager _userManager = userManager;

        [HttpGet]
        [Route("info/get-by-role")]
        public IActionResult GetUser()
        {
            var response = _userManager.GetUsersInfo(1);
            return Ok(response);
        }
    }
}
