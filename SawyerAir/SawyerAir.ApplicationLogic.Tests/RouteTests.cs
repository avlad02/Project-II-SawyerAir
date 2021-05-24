using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SawyerAir.Models;

namespace SawyerAir.ApplicationLogic.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void ChecksCorrectCreatedRoute()
        {
            //Arrange - define testing context
            string DepartureLocation = "Craiova";
            string DestinationLocation = "Paris";

            //Act - execute code under test
            var route = Route.Create(Guid.NewGuid(), DepartureLocation, DestinationLocation);

            //Assert - evaluate results
            Assert.AreEqual(DepartureLocation, route.DepartureLocation);
            Assert.AreEqual(DestinationLocation, route.DestinationLocation);
            Assert.IsInstanceOfType(route, typeof(Route));
        }

    }
}
