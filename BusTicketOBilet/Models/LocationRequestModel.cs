using Newtonsoft.Json;
using System;

namespace BusTicketOBilet.Models
{
    public class LocationRequestModel:IRequest
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
