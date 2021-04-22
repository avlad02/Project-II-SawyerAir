using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class PlaneClass
    {
        public Guid PlaneClassId { get; set; }
        public string ClassName { get; set; }
        public ICollection<Class_Info> Class_Infos { get; set; }
    }
}
