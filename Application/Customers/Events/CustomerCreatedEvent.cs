using System;
using MediatR;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Events
{
    public class CustomerCreatedEvent : BaseEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
