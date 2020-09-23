using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.DTO.Recommendation;

namespace CNX.Contracts.Interfaces
{
    public interface IRecommendationService
    {
        Task<List<RecommendationResponse>> GetRecommendationAsync(string userEmail);
    }
}
