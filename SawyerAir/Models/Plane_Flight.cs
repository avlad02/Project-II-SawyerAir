using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Plane_Flight
    {
        [Key, ForeignKey("Plane")]
        public int PlaneId { get; set; }

        [Key, ForeignKey("Flight")]
        public int FlightId { get; set; }

        public Plane Plane { get; set; }
        public Flight Flight { get; set; }
    }
}
