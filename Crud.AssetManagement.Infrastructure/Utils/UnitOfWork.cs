using System.Threading.Tasks;
using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Commits pending changes on the request's shared ISession inside a transaction.
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;

        protected UnitOfWork(ISession session)
        {
            _session = session;
        }

        public virtual async Task FlushAsync()
        {
            using var transaction = _session.BeginTransaction();
            await _session.FlushAsync();
            await transaction.CommitAsync();
        }
    }
}
