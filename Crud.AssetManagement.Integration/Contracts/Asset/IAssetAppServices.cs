using System.Threading.Tasks;
using Crud.AssetManagement.Queries.Asset.GetAssetById;

namespace Crud.AssetManagement.Integration.Contracts.Asset
{
    public interface IAssetAppServices
    {
        Task<GetAssetByIdQueryResult> GetAssetByIdAsync(int assetId);
    }
}
