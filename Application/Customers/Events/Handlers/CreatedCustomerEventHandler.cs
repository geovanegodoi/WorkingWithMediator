using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WWM.Application.Customers.Events.Handlers
{
    public class CreatedCustomerEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            Thread.Sleep(3000);
            Console.WriteLine($"{DateTime.Now} :: Starting customer job...");
            Thread.Sleep(3000);
            Console.WriteLine($"{DateTime.Now} :: Sending test email to {notification.Email}");
            Thread.Sleep(3000);
            Console.WriteLine($"{DateTime.Now} :: Uploading account information to {notification.Name}");
            Thread.Sleep(3000);
            Console.WriteLine($"{DateTime.Now} :: Sending text message to number {notification.Phone}");
            Thread.Sleep(3000);
            Console.WriteLine($"{DateTime.Now} :: Stopping customer job...");

            return Task.CompletedTask;
        }
    }
}
