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
            string DestinationLocation = "Craiova";
            string DepartureLocation = "Bucharest";

            //Act - execute code under test
            var route = Route.Create(1, DestinationLocation, DepartureLocation);

            //Assert - evaluate results
            Assert.AreEqual(DestinationLocation, route.DestinationLocation);
            Assert.AreEqual(DepartureLocation, route.DepartureLocation);
            Assert.IsInstanceOfType(route, typeof(Route));
        }
    }
}
