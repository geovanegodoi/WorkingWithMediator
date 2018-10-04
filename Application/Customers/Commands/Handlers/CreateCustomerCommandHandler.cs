using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Persistence.Repository;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;

namespace WWM.Application.Customers.Commands.Handlers
{
    public class CreateCustomerCommandHandler : BaseHandler<ICustomerRepository, CreateCustomerCommand, CustomerDetailModel>
    {
        public CreateCustomerCommandHandler(ICustomerRepository repository) 
            : base(repository)
        {

        }

        public override async Task<CustomerDetailModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} :: CreateCustomerHandler.Handle >>>");

            var entity = Mapper.Map<Customer>(request);

            await Repository.Add(entity, cancellationToken);

            await Repository.SaveChanges(cancellationToken);

            Console.WriteLine($"{DateTime.Now} :: CreateCustomerHandler.Handle <<<");

            return Mapper.Map<CustomerDetailModel>(entity);
        }
    }
}
