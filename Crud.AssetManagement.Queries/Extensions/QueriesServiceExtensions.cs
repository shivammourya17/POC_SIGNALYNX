using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Signalynx;

namespace Crud.AssetManagement.Queries.Extensions
{
    public static class QueriesServiceExtensions
    {
        public static IServiceCollection AddQueriesServices(this IServiceCollection services)
        {
            services.AddSignalynx(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
