using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShortLinkBackend.DTOs;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;

namespace ShortLinkBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO credentials) // word, need refactoring + add dto
        {
            var user = await _userService.AuthenticateUserAsync(credentials.Name, credentials.Password);
            if (user == null)
            {
                return Unauthorized(new {message = "Incorrect login or password" });
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new { user.Id, user.Name, user.Role }
            });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] LoginDTO credentials) // works, add dto
        {
            var newUser = await _userService.AddUserAsync(credentials.Name, credentials.Password);
            if (newUser == null) 
            {
                return Unauthorized(new { message = "Cannot create an account" });
            }

            var token = _tokenService.GenerateToken(newUser);

            return Ok(new
            {
                token,
                user = new { newUser.Id, newUser.Name, newUser.Role }
            });
        }
    }
}
