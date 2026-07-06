namespace Crud.AssetManagement.Infrastructure.Contracts.Asset
{
    public interface IAssetUnitOfWork : IUnitOfWork
    {
        IAssetRepository AssetRepository { get; }
    }
}
