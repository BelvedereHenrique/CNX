using System;

namespace CNX.Contracts.Entities
{
    public class HttpLogModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Method { get; set; }
        public string Payload { get; set; }
        public DateTime RequestedOn { get; set; }
        public string IpAddress { get; set; }
    }
}
