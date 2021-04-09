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
        public int Route_StopId { get; set; }
        public int StopId { get; set; }
        public int RouteId { get; set; }
        public float StopTime { get; set; }
        public Stop Stop { get; set; }
        public Route Route { get; set; }
    }
}
