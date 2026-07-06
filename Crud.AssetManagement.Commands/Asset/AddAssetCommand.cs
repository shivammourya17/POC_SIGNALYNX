using CSharpFunctionalExtensions;
using MediatR;

namespace Crud.AssetManagement.Commands.Asset
{
    public class AddAssetCommand : BaseAssetCommand, IRequest<Result<string>>
    {
    }
}
