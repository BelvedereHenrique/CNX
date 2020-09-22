using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CNX.Configs.Spotify;
using CNX.Contracts.DTO.Recommendation;
using CNX.Contracts.DTO.Spotify;
using CNX.Contracts.Enums;
using CNX.Contracts.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace CNX.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly IOptions<SpotifyApiConfiguration> _spotifyApiConfiguration;
        private const string AuthUrl = "https://accounts.spotify.com/api/token";
        private const string SearchUrl = "https://api.spotify.com/v1/search?q={genre}&type=playlist";


        public SpotifyService(IOptions<SpotifyApiConfiguration> spotifyApiConfiguration)
        {
            _spotifyApiConfiguration = spotifyApiConfiguration;
        }

        public async Task<List<RecommendationResponse>> GetPlaylistByTypeAsync(PlaylistTypeEnum recommend)
        {
            var token = await Authenticate();

            var searchResult = await SearchForPlaylists(recommend, token);

            var result = new List<RecommendationResponse>();

            searchResult.Playlists.Items.ToList().ForEach(x => result.Add(new RecommendationResponse(x.Name,x.External_Urls.Spotify)));

            return result;
        }

        private static async Task<SpotifyQueryPlaylistResponse> SearchForPlaylists(PlaylistTypeEnum recommend, string token)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", token);
            var url = SearchUrl.Replace("{genre}", recommend.ToString());

            var httpResult = await client.GetAsync(url);

            if (!httpResult.IsSuccessStatusCode)
                throw new HttpRequestException("Error while searching for playlists on Spotify.");

            var stringContent = await httpResult.Content.ReadAsStringAsync();

            var content = JsonConvert.DeserializeObject<SpotifyQueryPlaylistResponse>(stringContent);

            return content;
        }

        private async Task<string> Authenticate()
        {
            var clientId = _spotifyApiConfiguration.Value.ClientId;
            var clientSecret = _spotifyApiConfiguration.Value.ClientSecret;

            var base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var webRequest = (HttpWebRequest)WebRequest.Create(AuthUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + base64String);

            const string request = ("grant_type=client_credentials");
            var reqBytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = reqBytes.Length;

            var stream = webRequest.GetRequestStream();
            await stream.WriteAsync(reqBytes, 0, reqBytes.Length);
            stream.Close();

            var resp = (HttpWebResponse)webRequest.GetResponse();

            await using var respStr = resp.GetResponseStream();
            using var rdr = new StreamReader(respStr ?? throw new InvalidOperationException("Error while authenticating with Spotify"), Encoding.UTF8);
            var json = await rdr.ReadToEndAsync();
            rdr.Close();

            var result = JsonConvert.DeserializeObject<SpotifyAuthResponse>(json);
            return result.AccessToken;

        }
    }
}
