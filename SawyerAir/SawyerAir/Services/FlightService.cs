using SawyerAir.Models;
using SawyerAir.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SawyerAir.Services
{
    public class FlightService : BaseService
    {

        public FlightService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Flight> GetFlights()
        {
            return repositoryWrapper.FlightRepository.FindAll().ToList();
        }

        public List<Flight> GetFlightsByCondition(Expression<Func<Flight, bool>> expression)
        {
            return repositoryWrapper.FlightRepository.FindByCondition(expression).ToList();
        }

        public void AddFlight(Flight Flight)
        {
            repositoryWrapper.FlightRepository.Create(Flight);
        }

        public void UpdateFlight(Flight Flight)
        {
            repositoryWrapper.FlightRepository.Update(Flight);
        }

        public void DeleteFlight(Flight Flight)
        {
            repositoryWrapper.FlightRepository.Delete(Flight);
        }
    }
}
