using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Domain.Entities;

namespace WWM.Service
{
    public abstract class BaseService<TModel> : IService
        where TModel : class
    {
        protected readonly IMediator _mediator;

        protected IMediator Mediator => _mediator;

        public BaseService(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public abstract Task<List<TModel>> GetAll();

        //public abstract Task<TModel> GetById(Guid id, CancellationToken cancellationToken);
    }
}
