using Microsoft.VisualStudio.TestTools.UnitTesting;
using SawyerAir.Models;
using System.Collections.Generic;
using System.Text;
using System;

namespace SawyerAir.ApplicationLogic.Tests
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void ChecksCorrectCreatedLine()
        {
            //Arrange - define testing context
            string Name = "SawyerAirline";

            //Act - execute code under test
            var line = Line.Create(Guid.NewGuid(), Name);

            //Assert - evaluate results
            Assert.AreEqual(Name, line.Name);
            Assert.IsInstanceOfType(line, typeof(Line));
        }

    }
}
