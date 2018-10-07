using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.Repository;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Queries;

namespace WWM.Service.Customer
{
    public class CustomerService : BaseService<CustomerListModel>, ICustomerService
    {
        public CustomerService(IMediator mediator)
            : base(mediator)
        {

        }

        public async Task<IEnumerable<CustomerListModel>> GetCustomerList()
        {
            return await Mediator.Send(new GetCustomerListQuery());
        }

        public async Task<CustomerDetailModel> GetCustomerById(Guid Id)
        {
            return await Mediator.Send(new GetCustomerDetailQuery { Id = Id });
        }
    }
}
