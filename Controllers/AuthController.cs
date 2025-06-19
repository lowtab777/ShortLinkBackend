using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok("login");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok("logout");
        }
    }
}
