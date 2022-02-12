using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public float Credits { get; set; }

        [JsonIgnore]
        private string Token { get; set; }
    }
}
