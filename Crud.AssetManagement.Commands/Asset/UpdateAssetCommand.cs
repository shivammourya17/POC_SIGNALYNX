using CSharpFunctionalExtensions;
using MediatR;

namespace Crud.AssetManagement.Commands.Asset
{
    public class UpdateAssetCommand : BaseAssetCommand, IRequest<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
