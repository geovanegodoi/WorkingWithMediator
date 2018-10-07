using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Queries;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Queries.Handlers
{
    public class GetCustomerListQueryHandler : BaseHandler<ICustomerRepository, GetCustomerListQuery, List<CustomerListModel>>
    {
        public GetCustomerListQueryHandler(ICustomerRepository repository, IMediator mediator) 
            : base(repository, mediator)
        {

        }

        public override async Task<List<CustomerListModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await Repository.GetAll().Select(c =>
                new CustomerListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email
            }).ToListAsync(cancellationToken);
        }
    }
}
