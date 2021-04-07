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

        public DbSet <Line> Line { get; set; }
        public DbSet <Plane> Plane { get; set; }
        public DbSet<Flight> Flight { get; set; }
        
        public DbSet<Route> Route { get; set; }
        public DbSet<Stop> Stop { get; set; }
        public DbSet<Class_Info> Class_Info { get; set; }
        public DbSet<PlaneClass> PlaneClass { get; set; }
        public DbSet<Booked> Booked { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Route_Stop> Route_Stop { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Flight>()
                        .HasKey(o => new { o.PlaneId, o.RouteId });
                    modelBuilder.Entity<Class_Info>()
                        .HasKey(o => new { o.PlaneClassId, o.RouteId });
                    modelBuilder.Entity<Booked>()
                        .HasKey(o => new { o.ClientId, o.RouteId });
                    modelBuilder.Entity<Route_Stop>()
                        .HasKey(o => new { o.StopId, o.RouteId });
        }
    }
}
