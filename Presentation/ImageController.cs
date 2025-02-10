using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Presentation
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost("upload")]




        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                    return BadRequest("No image file uploaded.");
                var imagePath = await _imageService.SaveImage(image);
                return Ok(new { ImagePath = imagePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get")]
        public IActionResult GetImage(string imagePath)
        {
            if (!System.IO.File.Exists(imagePath))
                return NotFound("Image not found.");
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg"); 
        }
    }    
}
