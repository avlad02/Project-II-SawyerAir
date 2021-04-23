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
        public Guid Route_StopId { get; set; }
        public Guid StopId { get; set; }
        public Guid RouteId { get; set; }
        public float StopTime { get; set; }
        public Stop Stop { get; set; }
        public Route Route { get; set; }
    }
}
