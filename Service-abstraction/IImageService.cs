using Microsoft.AspNetCore.Http;

namespace Domain_Layer.Contracts
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile image);
    }

}
