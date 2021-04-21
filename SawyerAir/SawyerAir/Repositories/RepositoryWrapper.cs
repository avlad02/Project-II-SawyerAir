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