using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketOBiletDomain.Entities
{
    public class Location :TableBase
    {
        [Key]
        public int ID { get; set; }

        public int? ParentID { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Zoom { get; set; }

        public string TZCode { get; set; }

        public string WeatherCode { get; set; }

        public int? Rank { get; set; }

        public string ReferenceCode { get; set; }

        public string Keywords { get; set; }
    }
}
