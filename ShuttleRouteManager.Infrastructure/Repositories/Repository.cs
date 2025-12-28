using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Domain.Absractions;
using ShuttleRouteManager.Infrastructure.Context;
using System.Linq.Expressions;

namespace ShuttleRouteManager.Infrastructure.Repositories;

internal sealed class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity>
 where TEntity : Entity
{
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>()
            .Where(e => !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await context.Set<TEntity>()
            .Where(e => !e.IsDeleted)
            .Where(filter)
            .ToListAsync();
    }

    public IQueryable<TEntity> GetQuery()
    {
        return context.Set<TEntity>()
            .Where(e => !e.IsDeleted)
            .AsQueryable();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await context.Set<TEntity>()
            .Where(e => !e.IsDeleted)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await context.Set<TEntity>()
            .Where(e => !e.IsDeleted)
            .FirstOrDefaultAsync(filter);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        context.Set<TEntity>().Update(entity);
    }
}
