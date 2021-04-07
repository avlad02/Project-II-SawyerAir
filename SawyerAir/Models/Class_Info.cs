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
        [Key, ForeignKey("Class")]
        public int ClassId { get; set; }

        [Key, ForeignKey("Flight")]
        public int FlightId { get; set; }
        public int No_seats { get; set; }
        public int Price { get; set; }

        public Class Class { get; set; }
        public Flight Flight { get; set; }

    }
}
