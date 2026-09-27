using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Signalynx;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.DTOs.Asset.Enum;

namespace Crud.AssetManagement.Commands.Asset.Decorators
{
    // Pipeline behavior that runs before AddAssetCommandHandler and UpdateAssetCommandHandler.
    // Registered once per closed command type in CommandsServiceExtensions since the
    // constraint ties it to the asset commands (same shape as the
    // org's ValidateAssetObjectDecorator).
    public class ValidateAssetObjectDecorator<TRequest> : IPipelineBehavior<TRequest, Result<string>>
        where TRequest : BaseAssetCommand
    {
        public ValidateAssetObjectDecorator()
        {
        }

        public async ValueTask<Result<string>> HandleAsync(TRequest request, RequestHandlerDelegate<Result<string>> next, CancellationToken cancellationToken = default)
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
