using System;
using System.ComponentModel.DataAnnotations;
using WWM.Application.Customers.Commands;
using WWM.Application.Infrastructure;

namespace WWM.Application.Customers.Validatons
{
    public class CreateCustomerValidation
    {
        public ValidationResult Validate(CreateCustomerCommand command)
        {
            return new ValidationResult(string.Empty);
        }

        protected void ValidateId()
        {

        }
    }
}
