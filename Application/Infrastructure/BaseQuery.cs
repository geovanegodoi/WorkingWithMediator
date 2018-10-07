using System;
using MediatR;

namespace WWM.Application.Infrastructure
{
    public abstract class BaseQuery<TResponse> : BaseCommand, IRequest<TResponse>
    {

    }
}
