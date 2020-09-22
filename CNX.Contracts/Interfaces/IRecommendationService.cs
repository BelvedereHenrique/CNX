using System.Threading.Tasks;

namespace CNX.Contracts.Interfaces
{
    public interface IRecommendationService
    {
        Task<bool> GetRecommendation(string userEmail);
    }
}
