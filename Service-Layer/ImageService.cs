using Domain_Layer.Contracts;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Persistence.Data;
using SixLabors.ImageSharp; // Add this using directive
using SixLabors.ImageSharp.Processing;

public class ImageService : IImageService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public ImageService(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<CTScan> SaveImageAsync(IFormFile image)
    {
        // Validate the image
        if (image == null || image.Length == 0)
            throw new ArgumentException("No image uploaded.");

        // Generate a unique filename
        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
        var uploadPath = _config["FileStorage:ImagePath"];
        var fullPath = Path.Combine(uploadPath, uniqueFileName);

        // Create directory if missing
        Directory.CreateDirectory(uploadPath);

        // Save the image to disk
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        // Extract image dimensions using ImageSharp
        int width = 0, height = 0;
        using (var img = await SixLabors.ImageSharp.Image.LoadAsync(fullPath)) // Fully qualified name
        {
            width = img.Width;
            height = img.Height;
        }

        // Create CTScan entity with metadata
        var ctScan = new CTScan
        {
            FileName = image.FileName,         
            FilePath = fullPath,
            UploadDate = DateTime.UtcNow,
        };

        // Save to database
        await _context.CTScans.AddAsync(ctScan);
        await _context.SaveChangesAsync();

        return ctScan;
    }
}