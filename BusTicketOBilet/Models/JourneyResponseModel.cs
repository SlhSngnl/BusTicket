using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class JourneyResponseModel
    {
        [JsonProperty("data")]
        public JourneyResponseData[] Data { get; set; }

        [JsonProperty("status")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestID { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }
    }
}
