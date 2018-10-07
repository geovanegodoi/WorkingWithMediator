using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Persistence.Repository;

namespace WWM.Service
{
    public interface IService
    {

    }

    public interface IService<TModel> : IService
        where TModel : class        
    {
        Task<TModel> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<TModel>> GetAll();
    }
}
