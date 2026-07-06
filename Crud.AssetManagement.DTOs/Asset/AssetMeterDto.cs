namespace Crud.AssetManagement.DTOs.Asset
{
    // Meter reading captured for meter-billed assets (copiers/printers).
    public class AssetMeterDto
    {
        public int InitialColorMeter { get; set; }
        public int InitialBwMeter { get; set; }
    }
}
