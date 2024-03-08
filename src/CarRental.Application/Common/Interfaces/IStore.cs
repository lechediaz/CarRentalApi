using CarRental.Domain.Entities.Base;

namespace CarRental.Application.Common.Interfaces;

public interface IStore<TEntity> where TEntity : EntityBase
{
    Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}