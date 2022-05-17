using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Epos.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public GenericRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Query()
        {
            return _session.Query<T>();
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Evict(T entity)
        {
            await _session.EvictAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _session.DeleteAsync(entity).Wait();
            await _session.FlushAsync();
        }
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public async Task Save(T entity)
        {
            try
            {
                _session.SaveOrUpdateAsync(entity).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _session.FlushAsync();
        }

        public async Task Merge(T entity)
        {
            try
            {
                _session.MergeAsync(entity).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _session.FlushAsync();
        }

        public IList<T> ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            var createQuery = _session.CreateSQLQuery(query).AddEntity(typeof(T));

            if (parameters != null)
                foreach (var item in parameters)
                    createQuery.SetParameter(item.Key, item.Value);

            return createQuery.List<T>().ToList();
        }

        public int ExecuteUpdateQuery(string query, Dictionary<string, object> parameters = null)
        {
            var createQuery = _session.CreateSQLQuery(query).AddEntity(typeof(T));

            if (parameters != null)
                foreach (var item in parameters)
                    createQuery.SetParameter(item.Key, item.Value);

            return createQuery.ExecuteUpdate();
        }
    }
}
