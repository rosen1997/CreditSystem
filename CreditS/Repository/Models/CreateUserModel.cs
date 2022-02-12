using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Models
{
    public class CreateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
