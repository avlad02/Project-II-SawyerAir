
using Microsoft.EntityFrameworkCore;
using SawyerAir.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SawyerAir.Models
{
    public class EFClientRepository : BaseRepository<Client>, IClientRepository
    {
       
        public EFClientRepository(FlightsContext dbContext):base(dbContext)
        { }

        public IEnumerable<Client> FindByLastName(string lastName)
        {
            var customersList = dbContext.Clients
                                .Where(customer => 
                                            customer.Name
                                            .ToLower()
                                            .Contains(lastName.ToLower()));

            return customersList.AsEnumerable();
        }

        public Client GetClientByUserId(Guid userId)
        {
            var foundClient = dbContext.Clients
                                .Where(client => client.Id == userId)
                                .FirstOrDefault();
            return foundClient;
        }

        public Client UpdateClientDetails(Guid clientId, Client clientDetails)
        {
            var clientEntity = dbContext.Update(clientDetails);
            dbContext.SaveChanges();
            return clientEntity.Entity;
        }
    }
}
