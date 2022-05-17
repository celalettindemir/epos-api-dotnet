using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(T entity);
        Task Merge(T entity);
        Task Delete(T entity);
        IQueryable<T> Query();
        IList<T> ExecuteQuery(string query, Dictionary<string, object> parameters = null);

        int ExecuteUpdateQuery(string query, Dictionary<string, object> parameters = null);
        Task Evict(T entity);
    }
}
