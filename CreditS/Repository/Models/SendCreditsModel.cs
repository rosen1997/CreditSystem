using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Models
{
    public class SendCreditsModel
    {
        public string SenderPhone { get; set; }
        public string ReceiverPhone { get; set; }
        public float Amount { get; set; }
        public string WishMessage { get; set; }
    }
}
