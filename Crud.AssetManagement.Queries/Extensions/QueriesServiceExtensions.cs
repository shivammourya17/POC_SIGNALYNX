using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.AssetManagement.Queries.Extensions
{
    public static class QueriesServiceExtensions
    {
        public static IServiceCollection AddQueriesServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
