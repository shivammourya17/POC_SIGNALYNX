using System.Collections.Generic;

namespace Crud.AssetManagement.Queries.Asset.GetAssetList
{
    public class GetAssetListQueryResult
    {
        public IList<AssetListItem> Items { get; set; } = new List<AssetListItem>();
    }

    public class AssetListItem
    {
        public int AssetId { get; set; }
        public int AssetTypeId { get; set; }
        public int AssetCategoryId { get; set; }
        public string AssetNo { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }
        public string AssetTagNo { get; set; }
        public int ClientId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ThirdPartyName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public decimal? ColorRate { get; set; }
        public decimal? BwRate { get; set; }
    }
}
