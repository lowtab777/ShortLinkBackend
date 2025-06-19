using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllUrls()
        {
            return Ok();
        }

        [HttpGet("/:id")]
        [Authorize(Roles = "User")]
        public IActionResult GetUrlById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CreateNewUrl()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public IActionResult DeleteUrl()
        {
            return Ok();
        }
    }
}
