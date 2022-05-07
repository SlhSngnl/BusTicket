using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class SessionRequestModel:IRequest
    {
        [JsonProperty("type")]
        public byte Type { get; set; }

        [JsonProperty("connection")]
        public ConnectionModel Connection { get; set; }

        [JsonProperty("browser")]
        public BrowserModel Browser { get; set; }
    }
}
