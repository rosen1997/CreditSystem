using AutoMapper;
using CreditS.Repository.Entities;
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

        public TransactionDataModel SendCredits(SendCreditsModel sendCreditsModel)
        {
            var sendingUser = unitOfWork.UserManager.GetByPhoneNumber(sendCreditsModel.SenderPhone);
            var receivingUser = unitOfWork.UserManager.GetByPhoneNumber(sendCreditsModel.ReceiverPhone);

            if (receivingUser == null)
            {
                //TODO: throw exception no user with that phone found
            }

            var transaction = new TransactionData
            {
                ReceivingUserId = receivingUser.Id,
                SendingUserId = sendingUser.Id,
                Amount = sendCreditsModel.Amount,
                WishMessage = sendCreditsModel.WishMessage
            };

            sendingUser.Credits -= sendCreditsModel.Amount;
            receivingUser.Credits += sendCreditsModel.Amount;

            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.UserManager.Update(sendingUser);
                unitOfWork.UserManager.Update(receivingUser);
                unitOfWork.TransactionDataManager.Create(transaction);

                unitOfWork.CommitTransaction();
                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw new Exception("Transaction could not be completed", ex);
            }

            return mapper.Map<TransactionDataModel>(transaction);
        }
    }
}
