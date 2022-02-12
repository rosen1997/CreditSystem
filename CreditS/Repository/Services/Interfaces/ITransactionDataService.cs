using CreditS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Services.Interfaces
{
    public interface ITransactionDataService
    {
        IEnumerable<TransactionDataModel> GetAllTransactionsWithUsers();
        IEnumerable<TransactionDataModel> GetAllSentTransactions(string username);
        IEnumerable<TransactionDataModel> GetAllReceivedTransactions(string username);
        TransactionDataModel SendCredits(string senderPhone, string receiverPhone, float amount);
    }
}
