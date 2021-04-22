using SawyerAir.Models;

namespace SawyerAir.Repositories
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(FlightsContext flightsContext)
            : base(flightsContext)
        {
        }
    }
}
