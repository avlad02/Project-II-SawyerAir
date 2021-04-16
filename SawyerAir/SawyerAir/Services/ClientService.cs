using SawyerAir.Abstractions;
using SawyerAir.Exceptions;
using SawyerAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawyerAir.Services
{
    public class ClientService
    {
        private IClientRepository clientRepository;
        private IPersistenceContext persistContext;
        public ClientService(IPersistenceContext persistenceContext)
        {
            clientRepository = persistenceContext.ClientRepository;
            persistContext = persistenceContext;
        }

        public Client RegisterNewCustomer(string userId, string email, string name, string surname, string phoneNumber, string address)
        {
            var client = Client.Create(Guid.Parse(userId), email, name, surname,phoneNumber,address);
            client = clientRepository.Add(client);
            persistContext.SaveChanges();
            return client;

        }

        public Client UpdateClientDetails(Guid clientId, Client clientDetails)
        {
            return clientRepository.UpdateClientDetails(clientId, clientDetails);
        }

        public bool DeleteClient(Guid clientId)
        {
            return clientRepository.Remove(clientId);
        }

        public Client GetClientFromUserId(string userId)
        {
            Guid idToSearch = Guid.Parse(userId);
            var customer = clientRepository?.GetClientByUserId(idToSearch);
            if (customer == null)
            {
                throw new ClientNotFoundException(userId);
            }

            return customer;
        }
    }
}
