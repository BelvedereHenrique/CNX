using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO.Recommendation
{
    public class PopRecommendation : PlaylistRecommendationBase
    {
        public PopRecommendation()
        {
            this.TempFrom = 15;
            this.TempTo = 30;
        }
        public override PlaylistTypeEnum Recommend()
        {
            return PlaylistTypeEnum.Pop;
        }
    }
}
