using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.DTO.Recommendation;
using CNX.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNX.Controllers
{
    [Authorize]
    [Route("v1/recommendation")]
    public class RecommendationController : Controller
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public async Task<ActionResult< List<RecommendationResponse>>> Get()
        {
            var user = User.Identity.Name;
            return await _recommendationService.GetRecommendationAsync(user);
        }
    }
}
