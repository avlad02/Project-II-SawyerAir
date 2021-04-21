using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Client : DataEntity
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Card> Cards { get; set; }


        protected Client()
        {
        }
        public static Client Create(Guid userId, string email, string name, string surname, string phoneNumber, string address)
        {
            var newClient = new Client()
            {
                Id = userId,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                Bookings = new List<Booking>(),
                Cards = new List<Card>()
            };
            return newClient;
        }
    }
}
