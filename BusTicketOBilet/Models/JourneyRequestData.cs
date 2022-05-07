using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class JourneyRequestData
    {
        [JsonProperty("origin-id")]
        public int OriginID { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationID { get; set; }

        [JsonProperty("departure-date")]
        public string DepartureDate { get; set; }
    }
}
