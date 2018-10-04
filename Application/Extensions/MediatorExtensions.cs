using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WWM.Application.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task SendAsync<TResponse>(this IMediator mediator, IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : class
        {
            Task.Run(() => {
                mediator.Send(request, cancellationToken);
            });
        }

        public static async Task PublishAsync<TNotification>(this IMediator mediator, TNotification notification, CancellationToken cancellationToken = default(CancellationToken))
            where TNotification : INotification
        {
            Task.Run(() =>
            {
                mediator.Publish(notification, cancellationToken);
            }, cancellationToken);
        }
    }
}
