using System;
using MediatR;
using WWM.Persistence;

namespace WWM.Application.Infrastructure
{
    public abstract class BaseHandler<TRepository>
    {
        private readonly IMediator _mediator;
        private readonly TRepository _repository;

        protected IMediator Mediator => _mediator; // ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected TRepository Repository => _repository;

        public BaseHandler(TRepository repository)
        {
            _repository = repository;
        }
    }
}