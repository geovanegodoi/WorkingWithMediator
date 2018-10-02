using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;

namespace WWM.Application.Customers.Commands
{
    public class CreateCustomerHandler : BaseHandler<ICustomerRepository>, IRequestHandler<CreateCustomer, CustomerDetailModel>
    {
        public CreateCustomerHandler(ICustomerRepository repository) 
            : base(repository)
        {

        }

        public async Task<CustomerDetailModel> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Customer>(request);

            await Repository.Add(entity, cancellationToken);

            await Repository.SaveChanges(cancellationToken);

            return Mapper.Map<CustomerDetailModel>(entity);
        }
    }
}
