using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; } 
        public int RouteId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int FlightClass { get; set; }
        public DateTime BookingDate { get; set; }

        public Client Client { get; set; }
        public Route Route { get; set; }
    }
}
