using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Commands.Asset
{
    public class AddAssetCommandHandler : IRequestHandler<AddAssetCommand, Result<string>>
    {
        private readonly IAssetUnitOfWork _assetUnitOfWork;
        private readonly IMapper _mapper;

        public AddAssetCommandHandler(IAssetUnitOfWork assetUnitOfWork, IMapper mapper)
        {
            _assetUnitOfWork = assetUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(AddAssetCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AssetModel>(request);

            await _assetUnitOfWork.AssetRepository.SaveAsync(model);
            await _assetUnitOfWork.FlushAsync();

            return Result.Success(model.AssetId.ToString());
        }
    }
}
