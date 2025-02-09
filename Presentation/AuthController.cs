using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

    // Presentation/Controllers/PredictController.cs
    [Authorize]
    [ApiController]
    [Route("api/predict")]
    public class PredictController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IImageService _imageService;

        public PredictController(IModelService modelService, IImageService imageService)
        {
            _modelService = modelService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> Predict(IFormFile ctScan)
        {
            var imagePath = await _imageService.SaveImage(ctScan);
            var result = await _modelService.Predict(imagePath);
            return Ok(result);
        }
    }
}
