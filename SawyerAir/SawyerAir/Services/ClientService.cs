using SawyerAir.Abstractions;
using SawyerAir.Exceptions;
using SawyerAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SawyerAir.Repositories;
using System.Linq.Expressions;

namespace SawyerAir.Services
{
    public class ClientService : BaseService
    {

        public ClientService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        { 
        }

        public List<Client> GetClients()
        {
            return repositoryWrapper.ClientRepository.FindAll().ToList();
        }

        public List<Client> GetClientsByCondition(Expression<Func<Client, bool>> expression)
        {
            return repositoryWrapper.ClientRepository.FindByCondition(expression).ToList();
        }

        public void AddClient(Client Client)
        {
            repositoryWrapper.ClientRepository.Create(Client);
        }

        public void UpdateClient(Client Client)
        {
            repositoryWrapper.ClientRepository.Update(Client);
        }

        public void DeleteClient(Client Client)
        {
            repositoryWrapper.ClientRepository.Delete(Client);
        }

        public Client CreateClient(Guid userId, string email, string name, string surname, string phoneNumber, string address)
        {
            return Client.Create(userId, email, name, surname, phoneNumber, address);
        }

        public Client GetClientByUserId(string Id)
        {
            return GetClients().FirstOrDefault(m => m.Id == Guid.Parse(Id));
        }
    }
}
