using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace SawyerAir.Abstractions
{
    public interface IPersistenceContext: IDisposable
    {  
        IClientRepository ClientRepository { get; }               
        void SaveChanges();
    }
}
