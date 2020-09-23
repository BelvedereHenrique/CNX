namespace CNX.Contracts.DTO.Recommendation
{
    public class RecommendationResponse
    {
        public RecommendationResponse(string name, string spotifyAddress)
        {
            Name = name;
            SpotifyAddress = spotifyAddress;
        }

        public string SpotifyAddress { get; set; }
        public string Name { get; set; }
    }
}
