using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNX.Contracts.DTO.Recommendation;
using CNX.Contracts.DTO.Spotify;
using CNX.Contracts.Interfaces;

namespace CNX.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IUserService _userService;
        private readonly IWeatherMapsService _weatherMapsService;
        private readonly ISpotifyService _spotifyService;

        private List<PlaylistRecommendationBase> _recommendations;

        public RecommendationService(IUserService userService,
            IWeatherMapsService weatherMapsService,
            ISpotifyService spotifyService)
        {
            _userService = userService;
            _weatherMapsService = weatherMapsService;
            _spotifyService = spotifyService;

            InstantiateRecommendations();
        }

        public async Task<List<RecommendationResponse>> GetRecommendationAsync(string userEmail)
        {
            var result = new List<RecommendationResponse>();
            var user = await _userService.GetByEmailAsync(userEmail);
            
            var hometown = user.Hometown;

            var temperature = await _weatherMapsService.GetHometownTemperature(hometown);
            var recommend = _recommendations.FirstOrDefault(x => x.IsRightPlaylist(temperature))?.Recommend();

            if (recommend != null)
            {
                result = await _spotifyService.GetPlaylistByTypeAsync(recommend.Value);
            }

            return result;
        }

        private void InstantiateRecommendations()
        {
            _recommendations = typeof(PlaylistRecommendationBase)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(PlaylistRecommendationBase)) && !t.IsAbstract)
                .Select(t => (PlaylistRecommendationBase)Activator.CreateInstance(t)).ToList();
        }
    }
}
