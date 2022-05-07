using Newtonsoft.Json;
using System;

namespace BusTicketOBilet.Models
{
    public class JourneyResponseData
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("partner-id")]
        public string PartnerID { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("route-id")]
        public int RouteID { get; set; }

        [JsonProperty("bus-type")]
        public string BusType { get; set; }

        [JsonProperty("bus-type-name")]
        public string BusTypeName { get; set; }

        [JsonProperty("total-seats")]
        public int TotalSeats { get; set; }

        [JsonProperty("available-seats")]
        public int AvailableSeats { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("features")]
        public Features[] Features { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("is-active")]
        public bool isActive { get; set; }

        [JsonProperty("origin-location-id")]
        public int OriginLocationID { get; set; }

        [JsonProperty("destination-location-id")]
        public int DestinationLocationID { get; set; }

        [JsonProperty("is-promoted")]
        public bool isPromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        public int? CancellationOffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovID { get; set; }

        [JsonProperty("display-offset")]
        public TimeSpan DisplayOffset { get; set; }

        [JsonProperty("partner-rating")]
        public decimal? PartnerRating { get; set; }

        [JsonProperty("has-dynamic-pricing")]
        public bool HasDynamicPricing { get; set; }

        [JsonProperty("disable-sales-without-hes-code")]
        public bool DisableSalesWithoutHESCode { get; set; }

        [JsonProperty("disable-single-seat-selection")]
        public bool DisableSingleSeatSelection { get; set; }

        [JsonProperty("change-offset")]
        public int? ChangeOffset { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("display-coupon-code-input")]
        public bool DisplayCouponCodeInput { get; set; }

        [JsonProperty("disable-sales-without-date-of-birth")]
        public bool DisableSalesWithoutDateOfBirth { get; set; }
    }
}
