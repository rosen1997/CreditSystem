using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CreditS.Repository.RepositoryPattern.IRepositoryBase;

namespace CreditS.Repository.RepositoryPattern
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public int Count()
        {
            return RepositoryContext.Set<T>().Count();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public T FindById(int id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public virtual T FindById(string id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>();
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public IEnumerable<T> GetAllAsNoTracking()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }
    }
}
