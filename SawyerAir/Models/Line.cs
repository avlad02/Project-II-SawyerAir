using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Line
    {
        public int LineId     { get; set; }
        public string Location { get; set; }
        public ICollection<Plane> Planes { get; set; }
    }
}
