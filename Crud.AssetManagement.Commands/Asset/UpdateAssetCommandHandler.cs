using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Signalynx;
using Crud.AssetManagement.Commands.Utils;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;

namespace Crud.AssetManagement.Commands.Asset
{
    public class UpdateAssetCommandHandler : ICommandHandler<UpdateAssetCommand, Result<string>>
    {
        private readonly IAssetUnitOfWork _assetUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateAssetCommandHandler(IAssetUnitOfWork assetUnitOfWork, IMapper mapper)
        {
            _assetUnitOfWork = assetUnitOfWork;
            _mapper = mapper;
        }

        public async ValueTask<Result<string>> HandleAsync(UpdateAssetCommand request, CancellationToken cancellationToken = default)
        {
            var model = await _assetUnitOfWork.AssetRepository.GetByIdAsync(request.AssetId);

            if (model == null)
            {
                return Result.Failure<string>(string.Format(CommandMessageResource.NOT_EXISTS, "Asset"));
            }

            _mapper.Map(request, model);
            model.UpdatedDate = DateTime.UtcNow;

            await _assetUnitOfWork.FlushAsync();

            return Result.Success(model.AssetId.ToString());
        }
    }
}
