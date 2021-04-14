using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class FlightsContext: DbContext
    {
        public FlightsContext(DbContextOptions<FlightsContext> options )
            : base(options)
        { }

        public DbSet <Line> Lines { get; set; }
        public DbSet <Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        
        public DbSet<Route> Routes { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Class_Info> Class_Infos { get; set; }
        public DbSet<PlaneClass> PlaneClasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Route_Stop> Route_Stops { get; set; }
        public object Route { get; internal set; }
    }
}
