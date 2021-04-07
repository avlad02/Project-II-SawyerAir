using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Departure_Location { get; set; }
        public string Destination_Location { get; set; }
        public TimeSpan Departure_Hour { get; set; }
        public TimeSpan Destination_Hour { get; set; }

    }
}
