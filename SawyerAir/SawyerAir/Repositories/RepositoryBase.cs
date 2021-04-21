using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SawyerAir.Models;

namespace SawyerAir.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FlightsContext FlightsContext { get; set; }

        public RepositoryBase(FlightsContext flightsContext)
        {
            this.FlightsContext = flightsContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.FlightsContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FlightsContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.FlightsContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.FlightsContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.FlightsContext.Set<T>().Remove(entity);
        }

    }
}
