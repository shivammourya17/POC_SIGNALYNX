namespace Crud.AssetManagement.Queries.Shared
{
    // Shared search/paging fields, same role as the org's BaseQueryPagination.
    public abstract class BaseQueryPagination
    {
        public string Q { get; set; }
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
