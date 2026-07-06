using Microsoft.Extensions.DependencyInjection;

namespace Crud.AssetManagement.Extensions
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
