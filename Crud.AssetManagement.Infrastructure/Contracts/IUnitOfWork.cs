using System.Threading.Tasks;

namespace Crud.AssetManagement.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        Task FlushAsync();
    }
}
