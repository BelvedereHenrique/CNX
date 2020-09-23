using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO.Recommendation
{
    public abstract class PlaylistRecommendationBase
    {
        protected int TempFrom { get; set; }
        protected int TempTo { get; set; }

        public abstract PlaylistTypeEnum Recommend();

        public virtual bool IsRightPlaylist(float temperature)
        {
            return temperature >= TempFrom && temperature <= TempTo;
        }
    }
}
