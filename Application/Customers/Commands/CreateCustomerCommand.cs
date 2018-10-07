using System;
using WWM.Application.Customers.Models;
using WWM.Application.Customers.Validatons;

namespace WWM.Application.Customers.Commands
{
    public class CreateCustomerCommand : BaseCustomerCommand<CustomerDetailModel>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
