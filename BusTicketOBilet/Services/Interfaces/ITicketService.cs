using BusTicketOBilet.Models;

namespace BusTicketOBilet.Services.Interfaces
{
    public interface ITicketService
    {
        IndexVM GetLocation(SessionModel model);

        JourneyVM GetJourney(IndexVM model);
    }
}
