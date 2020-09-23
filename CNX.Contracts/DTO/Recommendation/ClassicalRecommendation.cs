using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO.Recommendation
{
    public class ClassicalRecommendation : PlaylistRecommendationBase
    {
        public ClassicalRecommendation()
        {
            this.TempTo = 9;
        }

        public override PlaylistTypeEnum Recommend()
        {
            return PlaylistTypeEnum.Classical;
        }

        public override bool IsRightPlaylist(float temperature)
        {
            return temperature <= TempTo;
        }
    }
}
