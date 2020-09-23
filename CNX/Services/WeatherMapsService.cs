using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CNX.Configs;
using CNX.Configs.WeatherMaps;
using CNX.Contracts.DTO.WeatherMaps;
using CNX.Contracts.Interfaces;
using CNX.Utils;
using Microsoft.Extensions.Options;

namespace CNX.Services
{
    public class WeatherMapsService : IWeatherMapsService
    {
        private readonly string _apiKey;
        public WeatherMapsService(IOptions<WeatherMapsApiConfiguration> weatherMapsApiConfiguration)
        {
            _apiKey = weatherMapsApiConfiguration.Value.ApiKey;
        }

        private static readonly string WeatherApiUrl = "http://api.openweathermap.org/data/2.5/weather?q={City}&appid={ApiKey}&units=metric";

        public async Task<int> GetHometownTemperature(string userHometown)
        {
            var queryString = WeatherApiUrl.Replace("{City}", userHometown.Trim()).Replace("{ApiKey}", _apiKey);

            var result = await HttpUtil.GetAsync<WeatherMapsResult>(queryString);

            if (result == null || result.Cod != 200)
                throw new HttpResponseException("Error while getting current hometown temperature");

            var temperature = Convert.ToInt32(result.Main.Temp);
            return temperature;
        }
    }
}
