using System;
using System.Threading.Tasks;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Commands
{
    public class DeleteCustomerCommand : BaseCommand<Task>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
