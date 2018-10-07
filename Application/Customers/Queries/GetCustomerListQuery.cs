using System;
using System.Collections.Generic;
using MediatR;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerListQuery : BaseQuery<List<CustomerListModel>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
