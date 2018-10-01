using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Exceptions;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;
using WWM.Persistence.Context;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerDetailHandler : BaseHandler<ICustomerRepository>, IRequestHandler<GetCustomerDetail, CustomerDetailModel>
    {
        public GetCustomerDetailHandler(ICustomerRepository repository) 
            : base(repository)
        {
        }

        public async Task<CustomerDetailModel> Handle(GetCustomerDetail request, CancellationToken cancellationToken)
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
