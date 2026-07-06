using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Lightweight stand-in for the shared Crud BaseRepository<T>.
    // Swap the internals for the real shared implementation (NHibernate session, etc.)
    // once this module is wired into the actual data-access package.
    public abstract class BaseRepository<TModel> where TModel : class
    {
        private readonly List<TModel> _store = new List<TModel>();

        protected virtual Task AddAsync(TModel model)
        {
            _store.Add(model);
            return Task.CompletedTask;
        }

        protected virtual Task<TModel> FindByIdAsync(int id)
        {
            return Task.FromResult(_store.Count > 0 ? _store[0] : null);
        }

        protected virtual Task<IList<TModel>> FindListAsync(int perPage, int page)
        {
            return Task.FromResult((IList<TModel>)_store);
        }

        protected virtual Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
