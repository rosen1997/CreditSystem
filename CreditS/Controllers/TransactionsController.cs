using CreditS.Repository.Models;
using CreditS.Repository.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionDataService transactionDataService;

        public TransactionsController(ITransactionDataService transactionDataService)
        {
            this.transactionDataService = transactionDataService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetAllTransactionsWithUsers")]
        public IActionResult GetAllTransactionsWithUsers()
        {
            var transactions = transactionDataService.GetAllTransactionsWithUsers();

            return Ok(transactions);
        }


        [HttpPost]
        [Route("GetSentTransactions")]
        public IActionResult GetSentTransactions(string phone)
        {
            var transactions = transactionDataService.GetAllSentTransactions(phone);

            return Ok(transactions);
        }

        [HttpPost]
        [Route("GetReceivedTransactions")]
        public IActionResult GetReceivedTransactions(string phone)
        {
            var transactions = transactionDataService.GetAllReceivedTransactions(phone);

            return Ok(transactions);
        }

        [HttpPost]
        [Route("SendCredits")]
        public IActionResult SendCredits([FromBody] SendCreditsModel sendCreditsModel)
        {
            TransactionDataModel transactionDataModel = null;
            try
            {
                transactionDataModel = transactionDataService.SendCredits(sendCreditsModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok(transactionDataModel);
        }
    }
}
