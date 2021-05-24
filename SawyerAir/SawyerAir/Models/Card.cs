using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Models
{
    public class Card
    {
        public Guid CardId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime ExpirationDate { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Phone number must be 16 numbers long", MinimumLength = 16)]
        public string Number { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Phone number must be 3 numbers long", MinimumLength = 3)]
        public string CVC { get; set; }

        public Client Client { get; set; }
    }
}
