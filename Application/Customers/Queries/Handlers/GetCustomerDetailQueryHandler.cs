using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Queries;
using WWM.Application.Exceptions;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;
using WWM.Persistence.Context;

namespace WWM.Application.Customers.Queries.Handlers
{
    public class GetCustomerDetailQueryHandler : BaseHandler<ICustomerRepository, GetCustomerDetailQuery, CustomerDetailModel>
    {
        public GetCustomerDetailQueryHandler(ICustomerRepository repository) 
            : base(repository)
        {
        }

        public override async Task<CustomerDetailModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetById(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            return Mapper.Map<CustomerDetailModel>(entity);
        }
    }
}
