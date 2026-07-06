using AutoMapper;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Commands.Mapper
{
    // Maps commands straight onto the domain model, matching the org's
    // Commands/Mapper pattern (as opposed to the API-layer Mapper, which
    // maps DTO -> Command).
    public class AssetMapper : Profile
    {
        public AssetMapper()
        {
            CreateMap<AddAssetCommand, AssetModel>()
                .ForMember(dest => dest.AssetId, opt => opt.Ignore())
                .ForMember(dest => dest.InitialColorMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialColorMeter : (int?)null))
                .ForMember(dest => dest.InitialBwMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialBwMeter : (int?)null));

            CreateMap<UpdateAssetCommand, AssetModel>()
                .ForMember(dest => dest.InitialColorMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialColorMeter : (int?)null))
                .ForMember(dest => dest.InitialBwMeter, opt => opt.MapFrom(src => src.AssetMeter != null ? src.AssetMeter.InitialBwMeter : (int?)null));
        }
    }
}
