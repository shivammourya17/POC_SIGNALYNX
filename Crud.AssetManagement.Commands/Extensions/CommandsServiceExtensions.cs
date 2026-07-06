using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Asset.Decorators;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class CommandsServiceExtensions
    {
        public static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Registered as a closed generic because the decorator is constrained to AddAssetCommand.
            services.AddTransient(
                typeof(IPipelineBehavior<AddAssetCommand, CSharpFunctionalExtensions.Result<string>>),
                typeof(ValidateAssetObjectDecorator<AddAssetCommand>));

            return services;
        }
    }
}
