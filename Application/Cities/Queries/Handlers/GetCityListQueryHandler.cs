using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;
using WWM.Application.Cities.Models;
using WWM.Application.Infrastructure;

namespace WWM.Application.Cities.Queries.Handlers
{
    public class GetCityListQueryHandler : BaseHandler<ICityRepository, GetCityListQuery, List<CityListModel>>
    {
        public GetCityListQueryHandler(ICityRepository repository, IMediator mediator)
            : base(repository, mediator)
        {

        }

        public override async Task<List<CityListModel>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            return await Repository.GetAll().Select(c =>
                new CityListModel
                {
                    Id = c.Id,
                    Name = c.Name
            }).ToListAsync(cancellationToken);
        }
    }
}
