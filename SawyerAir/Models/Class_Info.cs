using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Class_Info
    {
        [Key, ForeignKey("PlaneClass")]
        public int PlaneClassId { get; set; }

        [Key, ForeignKey("Route")]
        public int RouteId { get; set; }
        public int Nr_seats { get; set; }
        public int Price { get; set; }

        public PlaneClass PlaneClass { get; set; }
        public Route Route { get; set; }

    }
}
