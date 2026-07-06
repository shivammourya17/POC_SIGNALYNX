using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Infrastructure.Contracts.Asset
{
    public interface IAssetRepository
    {
        Task SaveAsync(AssetModel model);
        Task<AssetModel> GetByIdAsync(int id);
        Task<IList<AssetModel>> GetListAsync(int perPage, int page);
        Task FlushAsync();
    }
}
