using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WWM.Application.Customers.Events.Handlers
{
    public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // notify by email the user was created
            // update a secondary database (e.g. external system)
            // create a task to be executed after the user creation
            return Task.CompletedTask;
        }
    }
}
