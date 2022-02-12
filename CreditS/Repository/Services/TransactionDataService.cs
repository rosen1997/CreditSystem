using AutoMapper;
using CreditS.Repository.Models;
using CreditS.Repository.Services.Interfaces;
using CreditS.Repository.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Services
{
    public class TransactionDataService : ITransactionDataService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TransactionDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<TransactionDataModel> GetAllReceivedTransactions(string phone)
        {
            var transactions = unitOfWork.TransactionDataManager.GetReceivedTransactionsByPhoneNumber(phone);

            return mapper.Map<IEnumerable<TransactionDataModel>>(transactions);
        }

        public IEnumerable<TransactionDataModel> GetAllSentTransactions(string phone)
        {
            var transactions = unitOfWork.TransactionDataManager.GetSentTransactionsByPhoneNumber(phone);

            return mapper.Map<IEnumerable<TransactionDataModel>>(transactions);
        }

        public IEnumerable<TransactionDataModel> GetAllTransactionsWithUsers()
        {
            var transactions = unitOfWork.TransactionDataManager.GetAllWithUsers();

            return mapper.Map<IEnumerable<TransactionDataModel>>(transactions);
        }

        public TransactionDataModel SendCredits(string senderPhone, string receiverPhone, float amount)
        {
            throw new NotImplementedException();
        }
    }
}
