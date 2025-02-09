using Domain_Layer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _config;

        public ImageService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            // Validate image file
            if (image == null || image.Length == 0)
                throw new ArgumentException("No image uploaded.");

            // Create upload directory if it doesn't exist
            var uploadPath = _config["FileStorage:ImagePath"];
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            // Generate a unique filename
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return filePath;
        }

    }
}
