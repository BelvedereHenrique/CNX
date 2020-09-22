using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO.Recommendation
{
    public class RockRecommendation : PlaylistRecommendationBase
    {
        public RockRecommendation()
        {
            this.TempFrom = 10;
            this.TempTo = 14;
        }
        public override PlaylistTypeEnum Recommend()
        {
            return PlaylistTypeEnum.Rock;
        }
    }
}
