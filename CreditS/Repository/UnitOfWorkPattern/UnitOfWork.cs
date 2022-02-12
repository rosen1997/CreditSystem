using CreditS.Repository.Managers;
using CreditS.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext repositoryContext;
        private bool disposedValue;

        public ILoginInfoManager LoginInfoManager { get; }

        public IRoleManager RoleManager { get; }

        public ITransactionDataManager TransactionDataManager { get; }

        public IUserManager UserManager { get; }

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            LoginInfoManager = new LoginInfoManager(repositoryContext);
            RoleManager = new RoleManager(repositoryContext);
            TransactionDataManager = new TransactionDataManager(repositoryContext);
            UserManager = new UserManager(repositoryContext);
        }

        public void RevertChanges()
        {
            foreach (var entry in repositoryContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                    case Microsoft.EntityFrameworkCore.EntityState.Detached:
                        entry.Reload();
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        break;
                    default: break;
                }
            }
        }
        public void SaveChanges()
        {
            repositoryContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            repositoryContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            repositoryContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            repositoryContext.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    repositoryContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
