using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.Repository;
using WWM.Persistence;

namespace WWM.Application.Infrastructure
{
    public abstract class BaseHandler<TRepository, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IMediator _mediator;

        private readonly TRepository _repository;

        protected IMediator Mediator => _mediator; // ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected TRepository Repository => _repository;

        protected BaseHandler(TRepository repository)
        {
            _repository = repository;
        }

        protected void NotifyValidationErros(BaseCommand command)
        {
            throw new NotImplementedException();
        }

        protected bool Commit()
        {
            return false;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}