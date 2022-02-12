using CreditS.Repository.Entities;
using CreditS.Repository.Managers.Interfaces;
using CreditS.Repository.RepositoryPattern;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<TransactionData> GetAllWithUsers()
        {
            return RepositoryContext.TransactionsData
                .Include(x => x.SendingUser)
                .Include(x => x.ReceivingUser).AsNoTracking();
        }

        public IEnumerable<TransactionData> GetReceivedTransactionsByPhoneNumber(string phone)
        {
            return RepositoryContext.TransactionsData
                .Include(x => x.SendingUser)
                .Include(x => x.ReceivingUser)
                .Where(x => x.ReceivingUser.PhoneNumber.Equals(phone)).AsNoTracking();
        }

        public IEnumerable<TransactionData> GetSentTransactionsByPhoneNumber(string phone)
        {
            return RepositoryContext.TransactionsData
               .Include(x => x.SendingUser)
               .Include(x => x.ReceivingUser)
               .Where(x => x.SendingUser.PhoneNumber.Equals(phone)).AsNoTracking();
        }
    }
}
