using CreditS.Repository.Entities;
using CreditS.Repository.Managers.Interfaces;
using CreditS.Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Managers
{
    public class RoleManager : RepositoryBase<Role>, IRoleManager
    {
        public RoleManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
