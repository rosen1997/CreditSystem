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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public UserModel Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserModel CreateUser(CreateUserModel createUserModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
