using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    // Presentation/Controllers/PredictController.cs
   
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

            var imagePath = await  _imageService.SaveImageAsync(ctScan);
            var result = await _modelService.PredictAsync(imagePath);
            return Ok(result);
        }
    }
}
