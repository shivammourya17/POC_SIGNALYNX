using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
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
            // One session factory for the app, one session per request shared by the repositories and unit of work.
            services.AddSingleton(sp => SessionFactoryBuilder.Build(
                sp.GetRequiredService<IConfiguration>().GetConnectionString("AssetManagementDb")));
            services.AddScoped(sp => sp.GetRequiredService<ISessionFactory>().OpenSession());

            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetUnitOfWork, AssetUnitOfWork>();

            // Backs the raw-SQL QueryBuilder used by the Queries project.
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}
