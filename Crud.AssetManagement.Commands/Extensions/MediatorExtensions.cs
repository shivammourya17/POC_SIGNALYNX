using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;

namespace Crud.AssetManagement.Commands.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task<Result<TResponse>> CommandDispatchAsync<TCommand, TResponse>(
            this IMediator mediator, IMapper mapper, object source)
            where TCommand : IRequest<Result<TResponse>>
        {
            var command = mapper.Map<TCommand>(source);

            return await mediator.Send(command);
        }
    }
}
