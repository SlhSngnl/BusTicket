using Newtonsoft.Json;
using System;

namespace BusTicketOBilet.Models
{
    public class JourneyRequestModel:IRequest
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("data")]
        public JourneyRequestData Data { get; set; }
    }
}
