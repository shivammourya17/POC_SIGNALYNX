using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.DTOs.Asset.Enum;

namespace Crud.AssetManagement.Commands.Asset.Decorators
{
    // Pipeline behavior that runs before AddAssetCommandHandler.
    // Registered as a closed generic in CommandsServiceExtensions since the
    // constraint ties it to AddAssetCommand specifically (same shape as the
    // org's ValidateAssetObjectDecorator).
    public class ValidateAssetObjectDecorator<TRequest> : IPipelineBehavior<TRequest, Result<string>>
        where TRequest : AddAssetCommand
    {
        public ValidateAssetObjectDecorator()
        {
        }

        public async Task<Result<string>> Handle(TRequest request, RequestHandlerDelegate<Result<string>> next, CancellationToken cancellationToken)
        {
            if (request.AssetTypeId == (int)AssetType.Other && request.AssetMeter != null)
            {
                return Result.Failure<string>(CommandMessageResource.INVALID_ASSETMETER_DETAILS);
            }
            else if ((request.AssetTypeId == (int)AssetType.Copier || request.AssetTypeId == (int)AssetType.Printer) && request.AssetMeter == null)
            {
                return Result.Failure<string>(string.Format(CommandMessageResource.NOT_EXISTS, CommandMessageResource.ASSET_METER));
            }

            return await next();
        }
    }
}
