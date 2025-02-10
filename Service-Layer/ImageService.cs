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
    public class ImageService: IImageService
    {
        private readonly IConfiguration _config;

        public ImageService(IConfiguration config)
        {
            _config = config;
        }

        #region Save Image Method
        public async Task<string> SaveImage(IFormFile image)
        {
            // Validate image file
            //if (image == null || image.Length == 0)
            //    throw new ArgumentException("No image uploaded.");

            // Validate file type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(image.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
                throw new ArgumentException("Invalid file type. Only JPG/PNG allowed.");

            var maxFileSize = 10 * 1024 * 1024; // 10MB
            if (image.Length > maxFileSize)
                throw new ArgumentException("File size exceeds 10MB.");

            var uploadPath = _config["FileStorage:ImagePath"];
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return filePath;
        }
        #endregion

    }
}
