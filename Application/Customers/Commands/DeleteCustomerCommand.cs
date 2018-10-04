using System;
using System.Threading.Tasks;

namespace WWM.Application.Customers.Commands
{
    public class DeleteCustomerCommand : BaseCustomerCommand<Task>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}
