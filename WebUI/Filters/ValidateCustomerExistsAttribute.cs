using System;
using Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System.Threading;

namespace WebUI.Filters
{
    public class ValidateCustomerExistsAttribute : TypeFilterAttribute
    {
        public ValidateCustomerExistsAttribute() : base(typeof(ValidateCustomerExistsFilter)) { }

        private class ValidateCustomerExistsFilter : IAsyncActionFilter
        {
            private readonly ICustomerRepository _repository;

            public ValidateCustomerExistsFilter(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (context.ActionArguments.ContainsKey("id"))
                {
                    var id = (Guid)context.ActionArguments["id"];
                    if (id != Guid.Empty)
                    {
                        var entity = await _repository.GetById(id, new CancellationTokenSource().Token);
                        if (entity == null)
                        {
                            context.Result = new NotFoundObjectResult(id);
                            return;
                        }
                    }
                }
                await next();
            }
        }
    }
}
