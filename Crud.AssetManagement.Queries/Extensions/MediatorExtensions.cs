using System.Threading.Tasks;
using MediatR;

namespace Crud.AssetManagement.Queries.Extensions
{
    public static class MediatorExtensions
    {
        public static Task<TResult> QueryDispatchAsync<TResult>(this IMediator mediator, IRequest<TResult> query)
        {
            return mediator.Send(query);
        }
    }
}
