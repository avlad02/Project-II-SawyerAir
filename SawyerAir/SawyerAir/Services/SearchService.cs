using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SawyerAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Services
{
    public class SearchService
    {
        private readonly IFlightsContext _context;
        public SearchService(IFlightsContext context)
        {
            _context = context; 
        }

        public  RouteDestLocView Search(string RouteDestLoc, string searchString)
        {
            IQueryable<string> destlocQuery = from m in _context.Routes
                                              orderby m.DestinationLocation
                                              select m.DestinationLocation;

            var routes = from m in _context.Routes
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                routes = routes.Where(s => s.DestinationLocation.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(RouteDestLoc))
            {
                routes = routes.Where(x => x.DestinationLocation == RouteDestLoc);
            }

            var RouteDestLocVM = new RouteDestLocView
            {
                DestinationLocations = new SelectList( destlocQuery.Distinct().ToList()),
                Routes = routes.ToList()
            };

            return RouteDestLocVM;
        }

    }
}
