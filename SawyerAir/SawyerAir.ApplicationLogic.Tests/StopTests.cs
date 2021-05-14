using Microsoft.VisualStudio.TestTools.UnitTesting;
using SawyerAir.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SawyerAir.ApplicationLogic.Tests
{
    [TestClass]
    class StopTests
    {
        [TestMethod]
        public void ChecksCorrectCreatedStop()
        {
            //Arrange - define testing context
            string StopLocation = "Pitesti";

            //Act - execute code under test
            var stop = Stop.Create(Guid.NewGuid(), StopLocation);

            //Assert - evaluate results
            Assert.AreEqual(StopLocation, stop.StopLocation);
            Assert.IsInstanceOfType(stop, typeof(Stop));
        }
    }
}
