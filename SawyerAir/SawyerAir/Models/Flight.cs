using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Flight
    {
        public int FlightId { get; set;  }
        public int PlaneId { get; set; }
        public int RouteId { get; set; }

        
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Display(Name ="Hour of departure")]
        public TimeSpan DepartureHour { get; set; }

        [Display(Name = "Hour of arrival")]
        public TimeSpan DestinationHour { get; set; }
        public Plane Plane { get; set; }
        public Route Route { get; set; }
    }
}
