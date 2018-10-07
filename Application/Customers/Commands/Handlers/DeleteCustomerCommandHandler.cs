using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.Repository;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Commands.Handlers
{
    public class DeleteCustomerCommandHandler : BaseHandler<ICustomerRepository, DeleteCustomerCommand, Task>
    {
        public DeleteCustomerCommandHandler(ICustomerRepository repository, IMediator mediator)
            : base(repository, mediator)
        {
        }

        public override async Task<Task> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await Repository.Remove(request.Id, cancellationToken);

            await Repository.SaveChanges(cancellationToken);

            return Task.CompletedTask;
        }
    }
}
