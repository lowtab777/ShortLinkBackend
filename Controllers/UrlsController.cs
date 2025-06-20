using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;
using ShortLinkBackend.Services;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IShortLinkService _shortLinkService;
        public UrlsController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUrls()
        {
            return Ok(await _shortLinkService.GetAllLinksAsync());
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetUrlById(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role)!;

            var link = await _shortLinkService.GetByIdAsync(id);

            if (link == null)
                return NotFound();

            if (link.CreatedById != userId && role != "Admin")
                return Forbid();

            return Ok(link);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ShortLink shortLink)
        {
            var existing = await _shortLinkService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();


            existing.LongUrl = shortLink.LongUrl;
            existing.ShortUrl = shortLink.ShortUrl;

            await _shortLinkService.UpdateShortLinkAsync(existing);
            return Ok(existing);
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> CreateNewUrl([FromBody] string longUrl)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _shortLinkService.CreateShortLinkAsync(longUrl, userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var success = await _shortLinkService.DeleteByIdAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
