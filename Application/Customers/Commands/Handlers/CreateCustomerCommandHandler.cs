using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Application.Customers.Commands;
using WWM.Application.Customers.Events;
using WWM.Application.Customers.Models;
using WWM.Application.Extensions;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;

namespace WWM.Application.Customers.Commands.Handlers
{
    public class CreateCustomerCommandHandler : BaseHandler<ICustomerRepository, CreateCustomerCommand, CustomerDetailModel>
    {
        public CreateCustomerCommandHandler(ICustomerRepository repository, IMediator mediator) 
            : base(repository, mediator)
        {

        }

        public override async Task<CustomerDetailModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} :: CreateCustomerHandler.Handle >>>");

            var entity = Mapper.Map<Customer>(request);

            await Repository.Add(entity, cancellationToken);

            await Repository.SaveChanges(cancellationToken);

            Mediator.PublishAsync(Mapper.Map<CustomerCreatedEvent>(request));

            Console.WriteLine($"{DateTime.Now} :: CreateCustomerHandler.Handle <<<");

            return Mapper.Map<CustomerDetailModel>(entity);
        }
    }
}
