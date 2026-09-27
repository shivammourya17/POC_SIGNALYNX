using CSharpFunctionalExtensions;
using Signalynx;

namespace Crud.AssetManagement.Commands.Asset
{
    public class UpdateAssetCommand : BaseAssetCommand, ICommand<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
