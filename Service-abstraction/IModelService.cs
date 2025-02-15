using Domain_Layer.Models;

namespace Domain_Layer.Contracts
{
    // Core/Interfaces/IModelService.cs
    public interface IModelService
    {
        Task<PredictionResult> PredictAsync(string imagePath);
    }

}
