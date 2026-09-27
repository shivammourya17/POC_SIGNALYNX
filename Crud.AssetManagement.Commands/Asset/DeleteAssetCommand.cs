using CSharpFunctionalExtensions;
using Signalynx;

namespace Crud.AssetManagement.Commands.Asset
{
    public class DeleteAssetCommand : ICommand<Result<string>>
    {
        public int AssetId { get; set; }
    }
}
