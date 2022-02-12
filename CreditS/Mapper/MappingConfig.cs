using AutoMapper;
using CreditS.Repository.Entities;
using CreditS.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            UserMap();
            UserModelMap();
            TransactionDataMap();
            TransactionDataModelMap();
            UserCreateMap();
        }

        public void UserMap()
        {
            CreateMap<User, UserModel>()
                ;
        }

        public void UserModelMap()
        {
            CreateMap<UserModel, User>()
                ;
        }

        public void TransactionDataMap()
        {
            CreateMap<TransactionData, TransactionDataModel>()
                ;
        }

        public void TransactionDataModelMap()
        {
            CreateMap<TransactionDataModel, TransactionData>()
                ;
        }

        public void UserCreateMap()
        {
            CreateMap<User, CreateUserModel>()
                ;
        }
    }
}
