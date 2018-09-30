using System;
using MediatR;
using WWM.Application.Customers.Models;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerDetail : IRequest<CustomerDetailModel>
    {
        public Guid Id { get; set; }
    }
}
