using System.Threading.Tasks;
using Signalynx;
using Crud.AssetManagement.Integration.Contracts.Asset;
using Crud.AssetManagement.Queries.Asset.GetAssetById;

namespace Crud.AssetManagement.Integration.Asset
{
    public class AssetAppServices : IAssetAppServices
    {
        private readonly ISignalynx _signalynx;

        public AssetAppServices(ISignalynx signalynx)
        {
            _signalynx = signalynx;
        }

        public async Task<GetAssetByIdQueryResult> GetAssetByIdAsync(int assetId)
        {
            return await _signalynx.QueryAsync<GetAssetByIdQuery, GetAssetByIdQueryResult>(new GetAssetByIdQuery(assetId));
        }
    }
}
