using CreditS.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        ILoginInfoManager LoginInfoManager { get; }
        IRoleManager RoleManager { get; }
        ITransactionDataManager TransactionDataManager { get; }
        IUserManager UserManager { get; }

        void RevertChanges();
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
