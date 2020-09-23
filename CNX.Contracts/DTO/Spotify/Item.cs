namespace CNX.Contracts.DTO.Spotify
{
    public class Item
    {
        public bool Collaborative { get; set; }
        public string Description { get; set; }
        public ExternalUrls External_Urls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public Image[] Images { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public object PrimaryColor { get; set; }
        public object Public { get; set; }
        public string SnapshotId { get; set; }
        public Tracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}