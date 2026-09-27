using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Signalynx;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Asset.Decorators;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class CommandsServiceExtensions
    {
        public static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            services.AddSignalynx(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // Registered per closed command type because the decorator is constrained to BaseAssetCommand.
                options.AddBehavior<ValidateAssetObjectDecorator<AddAssetCommand>>();
                options.AddBehavior<ValidateAssetObjectDecorator<UpdateAssetCommand>>();
            });

            return services;
        }
    }
}
