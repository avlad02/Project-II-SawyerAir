using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SawyerAir.Models;

namespace SawyerAir.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FlightsContext _flightsContext;
        private IClientRepository _clientRepository;
        private IFlightRepository _flightRepository;
        private IRouteRepository _routeRepository;

        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_flightsContext);
                }
                return _clientRepository;
            }
        }

        public IFlightRepository FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new FlightRepository(_flightsContext);
                }
                return _flightRepository;
            }
        }

        public IRouteRepository RouteRepository
        {
            get
            {
                if (_routeRepository == null)
                {
                    _routeRepository = new RouteRepository(_flightsContext);
                }
                return _routeRepository;
            }
        }

        public RepositoryWrapper(FlightsContext flightsContext)
        {
            _flightsContext = flightsContext;
        }

        public void Save()
        {
            _flightsContext.SaveChanges();
        }
    }
}