namespace BusTicketOBilet.Models
{
    public enum ResponseStatus
    {
        Success = 1,
        Timeout = 0,
        InvalidDepartureDate = -1,
        InvalidRoute = -2,
        InvalidLocation = -3,
    }
}
