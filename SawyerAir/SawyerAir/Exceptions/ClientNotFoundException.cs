using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public Guid ClientId { get; private set; }
        public string UserId { get; private set; }
        public ClientNotFoundException(Guid customerId) : base($"Client with id {customerId} was not found")
        {
            ClientId = customerId;
        }

        public ClientNotFoundException(string userId) : base($"Client with id {userId} was not found")
        {
            ClientId = Guid.Empty;
            UserId = userId;
        }
    }
}
