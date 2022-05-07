using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketOBiletDomain.Entities
{
    public class Session:TableBase
    {
        [Key]
        public string ClientIP { get; set; }

        public string ClientPort { get; set; }

        public string BrowserName { get; set; }

        public string BrowserVersion { get; set; }

        public string DeviceID { get; set; }

        public string SessionID { get; set; }
    }
}
