using SawyerAir.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SawyerAir.Abstractions
{
    public interface IClientRepository: IRepository<Client>
    {
        
        IEnumerable<Client> FindByLastName(string lastName);

        Client GetClientByUserId(Guid userId);

        Client UpdateClientDetails(Guid clientId, Client clientDetails);
    }
}
