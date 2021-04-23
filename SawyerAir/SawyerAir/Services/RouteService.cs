using SawyerAir.Models;
using SawyerAir.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SawyerAir.Services
{
    public class RouteService : BaseService
    {
        public RouteService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Route> GetRoutes()
        {
            return repositoryWrapper.RouteRepository.FindAll().ToList();
        }

        public List<Route> GetRoutesByCondition(Expression<Func<Route, bool>> expression)
        {
            return repositoryWrapper.RouteRepository.FindByCondition(expression).ToList();
        }

        public void AddRoute(Route Route)
        {
            repositoryWrapper.RouteRepository.Create(Route);
        }

        public void UpdateRoute(Route Route)
        {
            repositoryWrapper.RouteRepository.Update(Route);
        }

        public void DeleteRoute(Route Route)
        {
            repositoryWrapper.RouteRepository.Delete(Route);
        }
    }
}
