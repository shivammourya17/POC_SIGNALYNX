using MediatR;

namespace Crud.AssetManagement.Queries.Asset.GetAssetById
{
    public class GetAssetByIdQuery : IRequest<GetAssetByIdQueryResult>
    {
        public int AssetId { get; }

        public GetAssetByIdQuery(int assetId)
        {
            AssetId = assetId;
        }
    }
}
