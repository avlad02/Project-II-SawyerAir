using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Route_Stop
    {
        [Key, ForeignKey("Stop")]
        public int StopId { get; set; }

        [Key, ForeignKey("Route")]
        public int RouteId { get; set; }
        public float StopTime { get; set; }

        public Stop Stop { get; set; }
        public Route Route { get; set; }
    }
}
