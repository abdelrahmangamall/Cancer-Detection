// Presentation/Controllers/ImageController.cs
using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/scan")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly IModelService _modelService;

    public ImageController(
        IImageService imageService,
        IModelService modelService)
    {
        _imageService = imageService;
        _modelService = modelService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadCtScan(IFormFile ctScan)
    {
        try
        {
            // Save the image and get metadata
            var uploadedCtScan = await _imageService.SaveImageAsync(ctScan);

            // Pass the image to the ML model
            var prediction = await _modelService.PredictAsync(uploadedCtScan.FilePath);

            // Return prediction result with scan metadata
            return Ok(new
            {
                ScanId = uploadedCtScan.Id,
                uploadedCtScan.FileName,
                Prediction = prediction.Prediction,
                Confidence = prediction.Confidence
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal error: {ex.Message}");
        }
    }
}