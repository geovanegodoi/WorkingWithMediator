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


            return Task.CompletedTask;
        }
    }
}
