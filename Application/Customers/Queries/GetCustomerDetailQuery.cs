using System;
using WWM.Application.Customers.Models;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerDetailQuery : BaseQuery<CustomerDetailModel>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
