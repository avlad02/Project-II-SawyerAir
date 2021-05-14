using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class RouteDepLocView
    {
        public List<Route> Routes { get; set; }
        public SelectList DepartureLocations { get; set; }
        public string RouteDepLoc { get; set; }
        public string SearchString { get; set; }
    }
}
