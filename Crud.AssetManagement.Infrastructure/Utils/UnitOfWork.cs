using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Contracts;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Lightweight stand-in for the shared Crud UnitOfWork base class.
    public abstract class UnitOfWork : IUnitOfWork
    {
        public virtual Task FlushAsync()
        {
            return Task.CompletedTask;
        }
    }
}
