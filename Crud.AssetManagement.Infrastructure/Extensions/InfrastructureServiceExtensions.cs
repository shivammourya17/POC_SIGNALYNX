using Microsoft.Extensions.DependencyInjection;
using Crud.AssetManagement.Infrastructure.Contracts;
using Crud.AssetManagement.Infrastructure.Contracts.Asset;
using Crud.AssetManagement.Infrastructure.Repositories.Asset;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetUnitOfWork, AssetUnitOfWork>();

            // Backs the raw-SQL QueryBuilder used by the Queries project.
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
