using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Card
    {
        public int CardId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Number { get; set; }
        public int CVC { get; set; }

        public Client Client { get; set; }
    }
}
