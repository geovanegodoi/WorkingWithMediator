using System;
using System.Collections.Generic;
using MediatR;
using WWM.Application.Customers.Models;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerList : IRequest<List<CustomerListModel>>
    {
    }
}
