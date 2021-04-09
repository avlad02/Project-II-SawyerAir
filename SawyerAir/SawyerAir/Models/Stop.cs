using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Stop
    {
        public int StopId { get; set; }
        public string StopLocation { get; set; }

        public ICollection<Route_Stop> Route_Stops { get; set; }
    }
}
