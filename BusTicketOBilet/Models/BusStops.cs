using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class BusStops
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public int Station { get; set; }

        [JsonProperty("time")]
        public string DateTime { get; set; }

        [JsonProperty("is-origin")]
        public bool isOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool isDestination { get; set; }
    }
}
