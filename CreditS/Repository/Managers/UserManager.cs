using CreditS.Repository.Entities;
using CreditS.Repository.Managers.Interfaces;
using CreditS.Repository.RepositoryPattern;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Managers
{
    public class UserManager : RepositoryBase<User>, IUserManager
    {
        public UserManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return RepositoryContext.Users.Where(x => x.PhoneNumber.Equals(phoneNumber)).AsNoTracking().FirstOrDefault();
        }

        public User GetByUsernameWithLoginInfo(string username)
        {
            return RepositoryContext.Users
                .Include(x => x.LoginInfo)
                .Where(x => x.LoginInfo.Username.Equals(username))
                .AsNoTracking()
                .SingleOrDefault();
        }
    }
}
