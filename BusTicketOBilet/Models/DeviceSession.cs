using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionID { get; set; }

        [JsonProperty("device-id")]
        public string DeviceID { get; set; }
    }
}
