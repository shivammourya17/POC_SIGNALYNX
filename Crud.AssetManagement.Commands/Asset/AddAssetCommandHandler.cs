using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Signalynx;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Commands.Asset
{
    public class AddAssetCommandHandler : ICommandHandler<AddAssetCommand, Result<string>>
    {
        private readonly IAssetUnitOfWork _assetUnitOfWork;
        private readonly IMapper _mapper;

        public AddAssetCommandHandler(IAssetUnitOfWork assetUnitOfWork, IMapper mapper)
        {
            _assetUnitOfWork = assetUnitOfWork;
            _mapper = mapper;
        }

        public async ValueTask<Result<string>> HandleAsync(AddAssetCommand request, CancellationToken cancellationToken = default)
        {
            var model = _mapper.Map<AssetModel>(request);
            model.CreatedDate = DateTime.UtcNow;

            await _assetUnitOfWork.AssetRepository.SaveAsync(model);
            await _assetUnitOfWork.FlushAsync();

            return Result.Success(model.AssetId.ToString());
        }
    }
}
