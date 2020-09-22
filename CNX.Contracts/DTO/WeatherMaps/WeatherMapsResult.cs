namespace CNX.Contracts.DTO.WeatherMaps
{
    public class WeatherMapsResult
    {
        public int Id { get; set; }
        public WeatherMapsCoord Coord { get; set; }
        public WeatherMapsWeather[] Weather { get; set; }
        public string Base { get; set; }
        public WeatherMapsMain Main { get; set; }
        public int Visibility { get; set; }
        public WeatherMapsWind Wind { get; set; }
        public WeatherMapsClouds Clouds { get; set; }
        public int Dt { get; set; }
        public WeatherMapsSys Sys { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
