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
        [Key, ForeignKey("Plane")]
        public int PlaneId { get; set; }

        [Key, ForeignKey("Route")]
        public int RouteId { get; set; }
        public TimeSpan Departure_Hour { get; set; }
        public TimeSpan Destination_Hour { get; set; }
        public Plane Plane { get; set; }
        public Route Route { get; set; }
    }
}
