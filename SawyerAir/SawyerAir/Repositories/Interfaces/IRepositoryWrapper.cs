namespace SawyerAir.Repositories
{
    public interface IRepositoryWrapper
    {
        IClientRepository ClientRepository { get; }
        IFlightRepository FlightRepository { get; }
        IRouteRepository RouteRepository { get; }
        void Save();
    }
}
