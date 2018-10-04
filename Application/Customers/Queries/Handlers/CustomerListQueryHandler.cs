using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Queries;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Queries.Handlers
{
    public class CustomerListQueryHandler : BaseHandler<ICustomerRepository, GetCustomerListQuery, List<CustomerListModel>>
    {
        public CustomerListQueryHandler(ICustomerRepository repository) 
            : base(repository)
        {

        }

        public override async Task<List<CustomerListModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} :: GetCustomerListHandler.Handle >>>");

            var model = await Repository.GetAll().Select(c =>
                new CustomerListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email
            }).ToListAsync(cancellationToken);

            Console.WriteLine($"{DateTime.Now} :: GetCustomerListHandler.Handle <<<");

            return model;
        }
    }
}
