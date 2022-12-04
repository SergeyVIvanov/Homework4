using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public abstract class ReadRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>
{
    protected DbContext Context { get; }
    protected DbSet<T> EntitySet { get; }

    protected ReadRepository(DbContext context)
    {
        Context = context;
        EntitySet = context.Set<T>();
    }

    public virtual T? Get(TPrimaryKey id)
    {
        return EntitySet.Find(id);
    }

    public virtual async Task<T?> GetAsync(TPrimaryKey id)
    {
        return await EntitySet.FindAsync(id);
    }

    public virtual IQueryable<T> GetAll(bool noTracking = false)
    {
        return noTracking ? EntitySet.AsNoTracking() : EntitySet;
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool noTracking = false)
    {
        return await GetAll(noTracking).ToListAsync(cancellationToken);
    }
}
