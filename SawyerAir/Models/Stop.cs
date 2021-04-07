using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Stop
    {
        public int FlightId { get; set; }
        public string StopAt { get; set; }
        public TimeSpan StopHour { get; set; }

        public Flight Flight { get; set; }
    }
}
