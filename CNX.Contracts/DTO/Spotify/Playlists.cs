namespace CNX.Contracts.DTO.Spotify
{
    public class Playlists
    {
        public string Href { get; set; }
        public Item[] Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }
}