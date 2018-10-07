using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.Repository;
using WWM.Application.Cities.Models;
using WWM.Application.Cities.Queries;

namespace WWM.Service.City
{
    public class CityService : BaseService<CityDetailModel>, ICityService
    {
        public CityService(IMediator mediator) 
            : base(mediator)
        {

        }

        public IEnumerable<CityListModel> GetCityList()
        {
            var model = Mediator.Send(new GetCityListQuery());
            return model.Result;
        }

        public CityDetailModel GetCityById(Guid Id)
        {
            var model = Mediator.Send(new GetCityDetailQuery { Id = Id });
            return model.Result;
        }
    }
}
