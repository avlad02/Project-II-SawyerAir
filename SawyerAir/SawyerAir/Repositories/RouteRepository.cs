using SawyerAir.Models;

namespace SawyerAir.Repositories
{
    public class RouteRepository : RepositoryBase<Route>, IRouteRepository
    {
        public RouteRepository(FlightsContext flightsContext)
            : base(flightsContext)
        {
        }
    }
}