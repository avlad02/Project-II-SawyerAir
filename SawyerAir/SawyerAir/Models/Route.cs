using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        [Display(Name = "Departure")]
        public string DepartureLocation { get; set; }

        [Display(Name = "Destination")]
        public string DestinationLocation { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Route_Stop> Route_Stops { get; set; }
        public ICollection<Class_Info> Class_Infos { get; set; }
        public ICollection<Booking> Bookings { get; set; }


        public static Route Create(Guid RouteId, string DepartureLocation, string DestinationLocation)
        {
            var newRoute = new Route()
            {
                RouteId = RouteId,
                DepartureLocation = DepartureLocation,
                DestinationLocation = DestinationLocation
            };
            return newRoute;
        }


    }
}
