using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketOBiletDomain
{
    public class OBiletAppSettings:IObiletAppSettings
    {
        public string Url { get; set; }
        public string ApiClientToken { get; set; }
        public string GetSession { get; set; }
        public string GetBusLocation { get; set; }
        public string GetBusJourney { get; set; }

    }
}
