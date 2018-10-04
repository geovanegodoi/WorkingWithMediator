using System;
using MediatR;

namespace WWM.Application.Infrastructure
{
    public class BaseEvent : INotification
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
