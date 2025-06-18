using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Returned value");
        } 
    }
}
