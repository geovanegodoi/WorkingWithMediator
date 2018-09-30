using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WWM.Application.Customers.Models;
using WWM.Application.Exceptions;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;
using WWM.Persistence;

namespace WWM.Application.Customers.Queries
{
    public class GetCustomerDetailHandler : BaseHandler<AppDbContext>, IRequestHandler<GetCustomerDetail, CustomerDetailModel>
    {
        public GetCustomerDetailHandler(AppDbContext context) 
            : base(context)
        {
        }

        public async Task<CustomerDetailModel> Handle(GetCustomerDetail request, CancellationToken cancellationToken)
        {
            var entity = await Context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            return Mapper.Map<CustomerDetailModel>(entity);
        }
    }
}
