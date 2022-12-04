using Domain.Entities;

namespace Services.Repositories.Abstractions;

public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
    where T : IEntity<TPrimaryKey>
{
    T Add(T entity);
    Task<T> AddAsync(T entity);

    bool Delete(TPrimaryKey id);
    Task<bool> DeleteAsync(TPrimaryKey id);

    void Update(T entity);

    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
