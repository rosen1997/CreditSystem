using CreditS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Services.Interfaces
{
    public interface IUserService
    {
        public UserModel Authenticate(string username, string password);
        public IEnumerable<UserModel> GetAllUsers();
        public UserModel CreateUser(CreateUserModel createUserModel);
    }
}
