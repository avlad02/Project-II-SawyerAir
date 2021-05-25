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
        public Guid StopId { get; set; }
        [Display(Name ="Stops")]
        public string StopLocation { get; set; }

        public ICollection<Route_Stop> Route_Stops { get; set; }


        public static Stop Create(Guid StopId, string StopLocation)
        {
            var newStop = new Stop()
            {
                StopId = StopId,
                StopLocation = StopLocation
            };
            return newStop;
        }
    }
}
