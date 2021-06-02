using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public interface IFlightsContext
    {
        public DbSet <Route> Routes { get; set; }
    }
}
