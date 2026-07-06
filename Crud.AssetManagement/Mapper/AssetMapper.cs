using AutoMapper;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.DTOs.Asset;

namespace Crud.AssetManagement.Mapper
{
    public class AssetMapper : Profile
    {
        public AssetMapper()
        {
            CreateMap<AssetDto, AddAssetCommand>();
            CreateMap<AssetDto, UpdateAssetCommand>();
            CreateMap<AssetDto, DeleteAssetCommand>();
        }
    }
}
