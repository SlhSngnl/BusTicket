using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class BrowserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
