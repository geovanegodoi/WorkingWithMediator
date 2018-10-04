using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WWM.Application.Infrastructure
{
    public abstract class BaseCommand
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }

    public abstract class BaseCommand<TResponse> : BaseCommand, IRequest<TResponse>
    {

    }
}
