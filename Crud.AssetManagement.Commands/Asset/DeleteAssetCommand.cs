using CSharpFunctionalExtensions;
using MediatR;

namespace Crud.AssetManagement.Commands.Asset
{
    public class DeleteAssetCommand : IRequest<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
