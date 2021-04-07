using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Booked
    {
        [Key, ForeignKey("Client")]
        public int ClientId { get; set; }

        [Key, ForeignKey("Flight")]
        public int FlightId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int FlightClass { get; set; }
        public DateTime BookingDate { get; set; }

        public Client Client { get; set; }
        public Flight Flight { get; set; }
    }
}
