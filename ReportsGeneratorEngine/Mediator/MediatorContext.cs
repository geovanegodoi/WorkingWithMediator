using System;
using System.Threading.Tasks;
using MediatR;

namespace ReportsGeneratorEngine.Mediator
{
    public interface IMediatorContext
    {
        Task Send(IRequest request);
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
        Task Publish(INotification notification);
    }

    public class MediatorContext : IMediatorContext
    {
        private readonly IMediator _mediator;

        public MediatorContext(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        public Task Send(IRequest request) => _mediator.Send(request);

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request) => _mediator.Send(request);

        public Task Publish(INotification notification) => _mediator.Publish(notification);
    }
}
