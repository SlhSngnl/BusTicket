namespace BusTicketOBilet.Models
{
    public class JourneyVM
    {
        public JourneyResponseData[] BusJourneyResponse { get; set; }

        public string OriginName { get; set; }

        public string DestinationName { get; set; }

        public string DeperatureDate { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public string UserMessage { get; set; } = string.Empty;
    }
}
