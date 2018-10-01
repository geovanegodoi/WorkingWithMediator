using System;
using MediatR;
using WWM.Application.Customers.Models;

namespace WWM.Application.Customers.Commands
{
    public class CreateCustomer : IRequest<CustomerDetailModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
