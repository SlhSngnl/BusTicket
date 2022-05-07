using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("zoom")]
        public string Zoom { get; set; }
    }
}
