using CSharpFunctionalExtensions;

using NHibernate;

using System;
using System.Data;
using System.Linq;

namespace CustomerManagement.Logic.SeedWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession session;
        private readonly ITransaction transaction;
        private bool _isAlive = true;
        private bool _isCommitted;

        public UnitOfWork(SessionFactory sessionFactory)
        {
            session = sessionFactory.OpenSession();
            transaction = session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            if (!_isAlive)
                return;

            _isAlive = false;

            try
            {
                if (_isCommitted)
                {
                    transaction.Commit();
                }
            }
            finally
            {
                transaction.Dispose();
                session.Dispose();
            }
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            _isCommitted = true;
        }

        internal Maybe<T> Get<T>(long id) where T : class
        {
            return session.Get<T>(id);
        }

        internal void SaveOrUpdate<T>(T aggregateRoot)
        {
            session.SaveOrUpdate(aggregateRoot);
        }

        internal void Delete<T>(T aggregateRoot)
        {
            session.Delete(aggregateRoot);
        }

        internal IQueryable<T> Query<T>()
        {
            return session.Query<T>();
        }
    }
}
