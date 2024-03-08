using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace CarRental.Infraestructure.Persistence.Stores;

public abstract class StoreBase<TEntity> : IStore<TEntity>
where TEntity : EntityBase
{
    private readonly ApplicationDbContext _dbContext;

    protected StoreBase(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Add(entity);

        await SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Update(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _dbContext.Set<TEntity>().AnyAsync("Id == @0", cancellationToken, new object[] { id });
    }
}