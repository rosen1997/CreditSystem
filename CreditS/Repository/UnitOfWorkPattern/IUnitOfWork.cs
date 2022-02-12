using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        void RevertChanges();
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
