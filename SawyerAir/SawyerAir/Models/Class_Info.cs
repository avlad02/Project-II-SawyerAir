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
        public Guid Class_InfoId { get; set; }
        public Guid PlaneClassId { get; set; }
        public Guid RouteId { get; set; }
        public int NrSeats { get; set; }
        public int Price { get; set; }

        public PlaneClass PlaneClass { get; set; }
        public Route Route { get; set; }

    }
}
