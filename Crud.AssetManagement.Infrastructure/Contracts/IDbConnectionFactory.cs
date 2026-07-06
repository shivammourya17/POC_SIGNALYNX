using System.Data;

namespace Crud.AssetManagement.Infrastructure.Contracts
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
