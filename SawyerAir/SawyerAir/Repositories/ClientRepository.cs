using SawyerAir.Models;

namespace SawyerAir.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(FlightsContext flightsContext)
            : base(flightsContext)
        {
        }
    }
}
