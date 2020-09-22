using System;
using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO.Recommendation
{
    public class PartyRecommendation : PlaylistRecommendationBase
    {
        public PartyRecommendation()
        {
            this.TempFrom = 30;
        }

        public override PlaylistTypeEnum Recommend()
        {
            return PlaylistTypeEnum.Rock;
        }

        public override bool IsRightPlaylist(float temperature)
        {
            return temperature > TempFrom;
        }
    }
}
