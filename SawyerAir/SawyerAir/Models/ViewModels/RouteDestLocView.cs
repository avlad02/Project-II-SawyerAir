using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class RouteDestLocView
    {
        public List<Route> Routes { get; set; }
        public SelectList DestinationLocations { get; set; }
        public string RouteDestLoc { get; set; }
        public string SearchString { get; set; }
    }
}
