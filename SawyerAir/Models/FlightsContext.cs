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
        public DbSet<Plane_Flight> Plane_Flight { get; set; }
        
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Stop> Stop { get; set; }
        public DbSet<Class_Info> Class_Info { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Booked> Booked { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Card> Card { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Plane_Flight>()
                        .HasKey(o => new { o.PlaneId, o.FlightId });
                    modelBuilder.Entity<Class_Info>()
                        .HasKey(o => new { o.ClassId, o.FlightId });
                    modelBuilder.Entity<Booked>()
                        .HasKey(o => new { o.ClientId, o.FlightId });
                    modelBuilder.Entity<Stop>()
                        .HasNoKey();
                }
    }
}
