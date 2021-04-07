using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Departure_Location { get; set; }
        public string Destination_Location { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Route_Stop> Route_Stops { get; set; }
        public ICollection<Class_Info> Class_Infos { get; set; }
        public ICollection<Booked> Bookeds { get; set; }


    }
}
