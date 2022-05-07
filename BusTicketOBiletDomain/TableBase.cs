using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketOBiletDomain
{
    public class TableBase
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string DeletedBy { get; set; }

    }
}
