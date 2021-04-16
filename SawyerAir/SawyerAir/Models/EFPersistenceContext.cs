using SawyerAir.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


namespace SawyerAir.Models
{
    public class EFPersistenceContext : IPersistenceContext
    {
        private readonly FlightsContext dbContext;
        public EFPersistenceContext(FlightsContext context)
        {
            this.dbContext = context;
            ClientRepository = new EFClientRepository(context);
        }

        public IClientRepository ClientRepository
        {
            get;
            private set;
        }

        public void Dispose()
        {
            
            dbContext.Dispose();
        }

        public void SaveChanges()
        {         
            dbContext.SaveChanges();
        }
    }
}
