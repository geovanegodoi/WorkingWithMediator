using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWM.Application.Cities.Models;

namespace WWM.Service.City
{
    public interface ICityService : IService
    {
        IEnumerable<CityListModel> GetCityList();
        CityDetailModel GetCityById(Guid Id);
    }
}