using System;
using System;
using System.Collections.Generic;
using WWM.Application.Cities.Models;
using WWM.Application.Infrastructure;

namespace WWM.Application.Cities.Queries
{
    public class GetCityListQuery : BaseQuery<List<CityListModel>>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
