using Microsoft.Extensions.DependencyInjection;
using Crud.AssetManagement.Integration.Contracts.Asset;

namespace Crud.AssetManagement.Integration.Extensions
{
    public static class IntegrationServiceExtensions
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
        {
            services.AddScoped<IAssetAppServices, Crud.AssetManagement.Integration.Asset.AssetAppServices>();

            return services;
        }
    }
}
