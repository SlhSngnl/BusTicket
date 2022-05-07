using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class ConnectionModel
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }
    }
}
