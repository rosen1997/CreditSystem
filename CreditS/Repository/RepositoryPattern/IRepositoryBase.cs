using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.RepositoryPattern
{
    public interface IRepositoryBase
    {
        public interface IRepositoryBase<T> where T : class
        {
            /// <summary>
            /// Read whole table content
            /// </summary>
            /// <returns>All entries in table</returns>
            IEnumerable<T> GetAll();

            /// <summary>
            /// Read whole table content as no tracking
            /// </summary>
            /// <returns>All entries in table</returns>
            IEnumerable<T> GetAllAsNoTracking();

            /// <summary>
            /// Find an entry by id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            T FindById(int id);

            T FindById(string id);

            /// <summary>
            /// Add one entry to table
            /// </summary>
            /// <param name="entity">Entry to add</param>
            void Create(T entity);

            /// <summary>
            /// Update specific entry based on PK
            /// </summary>
            /// <param name="entity">Entry to update</param>
            void Update(T entity);

            /// <summary>
            /// Delete specific entry based on PK
            /// </summary>
            /// <param name="entity">Entry to delete</param>
            void Delete(T entity);

            /// <summary>
            /// Count all entries
            /// </summary>
            /// <returns></returns>
            int Count();
        }
    }
}
