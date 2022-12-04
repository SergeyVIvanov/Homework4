using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public abstract class Repository<T, TPrimaryKey> : ReadRepository<T, TPrimaryKey>, IRepository<T, TPrimaryKey> where T 
    : class, IEntity<TPrimaryKey>
{
    protected Repository(DbContext context): base(context)
    {
    }

    public virtual T Add(T entity)
    {
        return EntitySet.Add(entity).Entity;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        return (await EntitySet.AddAsync(entity)).Entity;
    }

    public virtual bool Delete(TPrimaryKey id)
    {
        var entity = EntitySet.Find(id);
        if (entity != null)
            EntitySet.Remove(entity);
        return entity != null;
    }

    public virtual async Task<bool> DeleteAsync(TPrimaryKey id)
    {
        var entity = await EntitySet.FindAsync(id);
        if (entity != null)
            EntitySet.Remove(entity);
        return entity != null;
    }

    public virtual void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void SaveChanges()
    {
        Context.SaveChanges();
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }
}
