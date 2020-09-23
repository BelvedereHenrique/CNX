using Newtonsoft.Json;

namespace CNX.Contracts.DTO.Spotify
{
    public class SpotifyAuthResponse
    {
        [JsonProperty(propertyName:"access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(propertyName: "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(propertyName: "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(propertyName: "scope")]
        public string Scope { get; set; }
    }
}
