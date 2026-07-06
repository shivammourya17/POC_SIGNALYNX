using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Repositories.Asset
{
    public class AssetUnitOfWork : UnitOfWork, IAssetUnitOfWork
    {
        public IAssetRepository AssetRepository { get; }

        public AssetUnitOfWork(IAssetRepository assetRepository)
        {
            AssetRepository = assetRepository;
        }
    }
}
