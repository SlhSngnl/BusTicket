using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class Features
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("priority")]
        public byte? Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool isPromoted { get; set; }

        [JsonProperty("back-color")]
        public string BackColor { get; set; }

        [JsonProperty("fore-color")]
        public string ForeColor { get; set; }
    }
}
