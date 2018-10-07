using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWM.Domain.Entities;
using WWM.Persistence.Context;

namespace Persistence.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<City>> GetByCountryName(string country)
        {
            var entity = await Context.Countries
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(c => c.Name == country);

            return await DbSet.AsNoTracking()
                              .Where(c => c.CountryId == entity.Id)
                              .ToListAsync();
        }
    }
}