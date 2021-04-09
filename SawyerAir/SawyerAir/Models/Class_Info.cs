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
        public int Class_InfoId { get; set; }
        public int PlaneClassId { get; set; }
        public int RouteId { get; set; }
        public int NrSeats { get; set; }
        public int Price { get; set; }

        public PlaneClass PlaneClass { get; set; }
        public Route Route { get; set; }

    }
}
