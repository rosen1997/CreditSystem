using CreditS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CreditS.Repository.RepositoryPattern.IRepositoryBase;

namespace CreditS.Repository.Managers.Interfaces
{
    public interface ITransactionDataManager : IRepositoryBase<TransactionData>
    {
        IEnumerable<TransactionData> GetAllWithUsers();
        IEnumerable<TransactionData> GetSentTransactionsByPhoneNumber(string phone);
        IEnumerable<TransactionData> GetReceivedTransactionsByPhoneNumber(string phone);
    }
}
