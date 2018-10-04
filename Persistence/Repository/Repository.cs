using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWM.Domain.Entities;
using WWM.Persistence.Context;

namespace Persistence.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity obj, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} :: Repository.Add >>>");

            await DbSet.AddAsync(obj, cancellationToken);

            Console.WriteLine($"{DateTime.Now} :: Repository.Add <<<");
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            Console.WriteLine($"{DateTime.Now} :: Repository.GetAll >>>");

            return DbSet;
        }

        public virtual async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(Guid id, CancellationToken cancellationToken)
        {
            var entity = await DbSet.FindAsync(id, cancellationToken);
            Context.Remove(entity);
        }

        public virtual async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now} :: Repository.SaveChanges >>>");

            var result = await Context.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"{DateTime.Now} :: Repository.SaveChanges <<<");

            return result;
        }

        public async virtual Task Update(TEntity obj, CancellationToken cancellationToken)
        {
            await Task.Run(()=>DbSet.Update(obj), cancellationToken);
        }
    }
}
