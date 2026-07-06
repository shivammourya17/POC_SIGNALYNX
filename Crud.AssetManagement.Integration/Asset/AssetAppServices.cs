using System.Threading.Tasks;
using MediatR;
using Crud.AssetManagement.Integration.Contracts.Asset;
using Crud.AssetManagement.Queries.Asset.GetAssetById;

namespace Crud.AssetManagement.Integration.Asset
{
    public class AssetAppServices : IAssetAppServices
    {
        private readonly IMediator _mediator;

        public AssetAppServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetAssetByIdQueryResult> GetAssetByIdAsync(int assetId)
        {
            return await _mediator.Send(new GetAssetByIdQuery(assetId));
        }
    }
}
