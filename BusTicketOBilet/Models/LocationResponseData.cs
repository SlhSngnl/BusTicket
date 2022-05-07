using Newtonsoft.Json;

namespace BusTicketOBilet.Models
{
    public class LocationResponseData
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("parent-id")]
        public int? ParentID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("zoom")]
        public string Zoom { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("tz-code")]
        public string TimeZoneCode { get; set; }

        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public string RefCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}
