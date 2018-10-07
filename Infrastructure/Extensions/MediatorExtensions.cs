using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using WWM.Application.Customers.Queries.Handlers;

namespace Infrastructure.Extensions
{
    public static class MediatorExtensions
    {
        public static void InjectMediatR(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddMediatR(typeof(GetCustomerListQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
