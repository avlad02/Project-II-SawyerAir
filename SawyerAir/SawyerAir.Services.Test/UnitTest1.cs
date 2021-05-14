using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SawyerAir.Models;
using SawyerAir.Repositories;
using System;

namespace SawyerAir.Services.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIfClientIsCreated()
        {
            Guid ClientId = Guid.NewGuid();
            string Name = "Name";
            string Surname = "Surname";
            string PhoneNumber = "PhoneNumber";
            string Email = "Email";
            string Address = "Address";

            Client client = Client.Create(ClientId, Name, Surname, PhoneNumber, Email, Address);

            Assert.IsInstanceOfType(client, typeof(Client));
        }

    }
}
