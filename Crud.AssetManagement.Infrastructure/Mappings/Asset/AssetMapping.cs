using FluentNHibernate.Mapping;
using Crud.AssetManagement.Infrastructure.Models.Asset;

namespace Crud.AssetManagement.Infrastructure.Mappings.Asset
{
    public class AssetMapping : ClassMap<AssetModel>
    {
        public AssetMapping()
        {
            Table("Asset");
            Schema("Asset");

            Id(x => x.AssetId).Column("AssetId").GeneratedBy.Identity();
            Map(x => x.AssetTypeId);
            Map(x => x.AssetCategoryId);
            Map(x => x.AssetNo);
            Map(x => x.Manufacturer);
            Map(x => x.ModelNo);
            Map(x => x.SerialNo);
            Map(x => x.AssetTagNo);
            Map(x => x.ClientId);
            Map(x => x.Location);
            Map(x => x.Description);
            Map(x => x.ThirdPartyName);
            Map(x => x.PhoneNo);
            Map(x => x.EmailAddress);
            Map(x => x.ColorRate);
            Map(x => x.BwRate);
            Map(x => x.InitialColorMeter);
            Map(x => x.InitialBwMeter);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
            Map(x => x.DeletedDate);
        }
    }
}
