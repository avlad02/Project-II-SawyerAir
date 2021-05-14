using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Line
    {
        public Guid LineId     { get; set; }
        public string Name { get; set; }
        public ICollection<Plane> Planes { get; set; }



        public static Line Create(Guid LineId, string Name)
        {
            var newLine = new Line()
            {
                LineId = LineId,
                Name = Name
            };
            return newLine;
        }
    }
}
