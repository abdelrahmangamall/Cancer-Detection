using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;

namespace Domain_Layer.Contracts
{
    public interface IImageService
    {
        Task<CTScan> SaveImageAsync(IFormFile image);
    }

}
