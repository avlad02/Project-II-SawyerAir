using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SawyerAir.Exceptions;
using SawyerAir.Models;
using SawyerAir.Repositories;
using SawyerAir.Services;

namespace SawyerAir.Tests
{
    [TestClass]
    public class ClientTests
    {

        private Mock<IClientRepository> clientRepositoryMock = new Mock<IClientRepository>();
        private Mock<IRepositoryWrapper> repositoryWrapper = new Mock<IRepositoryWrapper>();
        private ClientService clientService;
        private Guid userId;
        private Client testClient;
        private string name;
        private string surname;
        private string email;
        private string phoneNumber;
        private string address;
        List<Client> clientList;
        IQueryable<Client> clientQ;

        [TestInitialize]
        public void Initialize_Data_Tests()
        {

            repositoryWrapper.Setup(pc => pc.ClientRepository)
                                 .Returns(clientRepositoryMock.Object);
            clientService = new ClientService(repositoryWrapper.Object);
            userId = Guid.NewGuid();
            name = "Toma";
            surname = "Mihnea";
            email = "test@gmail.com";
            phoneNumber = "0728186167";
            address = "Craiova";
            testClient = Client.Create(userId,email,name,surname,phoneNumber,address);
            clientList = new List<Client>();
            clientList.Add(testClient);
            clientQ = clientList.AsQueryable();

        }
        [TestMethod]
        public void GetClientFromUserId_Throws_Exception_When_Client_Does_Not_Exist()
        {
            Assert.ThrowsException<ClientNotFoundException>(() =>
            {
                clientService.GetClientByUserId(Guid.NewGuid().ToString());

            });
        }
        [TestMethod]
        public void GetCustomerFromUserId_Returns_Correct_Customer_Object()
        {
            clientRepositoryMock.Setup(f => f.FindByCondition(c => c.Id == userId)).Returns(clientQ);
            var client = clientService.GetClientsByCondition(c => c.Id == userId).FirstOrDefault();
            Assert.IsNotNull(client);
            Assert.AreEqual(userId, client.Id);
            Assert.AreEqual(name, client.Name);
            Assert.AreEqual(surname, client.Surname);
            Assert.AreEqual(email, client.Email);
            Assert.AreEqual(phoneNumber, client.PhoneNumber);
            clientService.
        }
        
    }
}
