using System;
using WWM.Application.Cities.Models;
using WWM.Application.Infrastructure;

namespace WWM.Application.Cities.Queries
{
    public class GetCityDetailQuery : BaseQuery<CityDetailModel>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
