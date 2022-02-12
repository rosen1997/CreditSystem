using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Models
{
    public class TransactionDataModel
    {
        public int Id { get; set; }

        public UserModel SendingUser { get; set; }
        public UserModel ReceivingUser { get; set; }
        public float Amount { get; set; }
        public string WishMessage { get; set; }
    }
}
