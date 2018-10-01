using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;
using WWM.Persistence.Context;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerListHandler : BaseHandler<ICustomerRepository>, IRequestHandler<GetCustomerList, List<CustomerListModel>>
    {
        public GetCustomerListHandler(ICustomerRepository repository) 
            : base(repository)
        {

        }

        public async Task<List<CustomerListModel>> Handle(GetCustomerList request, CancellationToken cancellationToken)
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
