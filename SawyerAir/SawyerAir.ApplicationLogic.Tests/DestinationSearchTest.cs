using Microsoft.VisualStudio.TestTools.UnitTesting;
using SawyerAir.Models;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using SawyerAir.Controllers;
using SawyerAir.Services;

namespace SawyerAir.ApplicationLogic.Tests
{
    [TestClass]
    public class DestinationSearchTest
    {
        [TestMethod]
        public void ChecksCorrectSearchedDestination()
        {

            var DataRoutes = new List<Route>
            {
                new Route(), new Route(), new Route()
            }.AsQueryable();

            foreach (var item in DataRoutes)
            {
                item.DepartureLocation = "Craiova";
                item.DestinationLocation = "Brasov";
            }

            var MockSet = new Mock<DbSet<Route>>();

            MockSet.As<IQueryable<Route>>().Setup(m => m.Provider).Returns(DataRoutes.Provider);
            MockSet.As<IQueryable<Route>>().Setup(m => m.Expression).Returns(DataRoutes.Expression);
            MockSet.As<IQueryable<Route>>().Setup(m => m.ElementType).Returns(DataRoutes.ElementType);
            MockSet.As<IQueryable<Route>>().Setup(m => m.GetEnumerator()).Returns(DataRoutes.GetEnumerator());

            var MockContext = new Mock<IFlightsContext>();

            MockContext.Setup(m => m.Routes).Returns(MockSet.Object);

            var Service = new SearchService(MockContext.Object);

            var Response = Service.Search(null, "Bra");
            Assert.AreEqual(Response.Routes.Count, 3);
        }

    }
}
