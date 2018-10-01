using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWM.Domain.Entities;

namespace Persistence.Repository
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : Entity
    {
        Task Add(TEntity obj, CancellationToken cancellationToken);
        Task<TEntity> GetById(Guid id, CancellationToken cancellationToken);
        IQueryable<TEntity> GetAll();
        Task Update(TEntity obj, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);
        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
