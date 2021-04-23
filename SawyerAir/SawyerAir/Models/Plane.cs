using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Plane
    {
        public Guid PlaneId        { get; set; }
        public string Model        { get; set; }
        public string Manufacturer { get; set; }

        [ForeignKey("Line")]
        public Guid LineId         { get; set; }
        public Line Line           { get; set; }

        public ICollection<Flight> Flight { get; set; }
    }
}
