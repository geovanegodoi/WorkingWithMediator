using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence.Repository;
using WWM.Application.Cities.Models;
using WWM.Application.Exceptions;
using WWM.Application.Infrastructure;
using WWM.Domain.Entities;

namespace WWM.Application.Cities.Queries.Handlers
{
    public class GetCityDetailQueryHandler : BaseHandler<ICityRepository, GetCityDetailQuery, CityDetailModel>
    {
        public GetCityDetailQueryHandler(ICityRepository repository, IMediator mediator)
            : base(repository, mediator)
        {
        }

        public async override Task<CityDetailModel> Handle(GetCityDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetById(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }
            return Mapper.Map<CityDetailModel>(entity);
        }
    }
}
