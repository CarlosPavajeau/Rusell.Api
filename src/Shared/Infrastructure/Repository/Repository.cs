using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Domain.Repository;

namespace Rusell.Shared.Infrastructure.Repository;

public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbContext Context;

    protected Repository(DbContext context)
    {
        Context = context;
    }

    public async Task Save(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public abstract Task<TEntity> Find(TKey key, bool noTracking);

    public async Task<TEntity> Find(TKey key) => await Find(key, true);

    public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate) =>
        await Context.Set<TEntity>().AnyAsync(predicate);

    public async Task<IEnumerable<TEntity>> SearchAll() => await Context.Set<TEntity>().AsNoTracking().ToListAsync();

    public async Task Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}