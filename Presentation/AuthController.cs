using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = await _authService.Register(dto.Email, dto.Password);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _authService.Login(dto.Email, dto.Password);
            return Ok(new { Token = token });
        }
    }
}
