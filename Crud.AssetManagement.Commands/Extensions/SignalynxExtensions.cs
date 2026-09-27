using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Signalynx;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class SignalynxExtensions
    {
        public static async Task<Result<TResponse>> CommandDispatchAsync<TCommand, TResponse>(
            this ISignalynx signalynx, IMapper mapper, object source)
            where TCommand : ICommand<Result<TResponse>>
        {
            var command = mapper.Map<TCommand>(source);

            return await signalynx.DispatchAsync<TCommand, Result<TResponse>>(command);
        }
    }
}
