using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUrls()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUrlById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateNewUrl()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUrl()
        {
            return Ok();
        }
    }
}
