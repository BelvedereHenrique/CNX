using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.DTO.Recommendation;
using CNX.Contracts.Enums;

namespace CNX.Contracts.Interfaces
{
    public interface ISpotifyService
    {
        Task<List<RecommendationResponse>> GetPlaylistByTypeAsync(PlaylistTypeEnum recommend);
    }
}
