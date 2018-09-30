using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;
using WWM.Persistence;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerListHandler : BaseHandler<AppDbContext>, IRequestHandler<GetCustomerList, List<CustomerListModel>>
    {
        public GetCustomerListHandler(AppDbContext context) 
            : base(context)
        {

        }

        public Task<List<CustomerListModel>> Handle(GetCustomerList request, CancellationToken cancellationToken)
        {
            return Context.Customers.Select(c =>
                new CustomerListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email
                }).ToListAsync(cancellationToken);
        }
    }
}
