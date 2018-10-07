using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWM.Domain.Entities;

namespace Persistence.Repository
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetByCountryName(string country);
    }
}
