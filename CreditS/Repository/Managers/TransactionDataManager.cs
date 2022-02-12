using CreditS.Repository.Entities;
using CreditS.Repository.Managers.Interfaces;
using CreditS.Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Managers
{
    public class TransactionDataManager : RepositoryBase<TransactionData>, ITransactionDataManager
    {
        public TransactionDataManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
