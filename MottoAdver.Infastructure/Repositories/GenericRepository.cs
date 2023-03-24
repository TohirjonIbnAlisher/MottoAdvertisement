using Microsoft.EntityFrameworkCore;
using MottoAdver.Infastructure.DbContexts;
using System.Linq.Expressions;

namespace MotoAdd.Infastructure.Repositories;

public class GenericRepository<TEntity, TKey>
    : IGenericRepository<TEntity, TKey> where TEntity : class
{
    private readonly MottoAdverContext motoAddDbContext;

    public GenericRepository(MottoAdverContext motoAddDbContext)
    {
        this.motoAddDbContext = motoAddDbContext;
    }

    public async ValueTask<TEntity> PostEntityAsync(TEntity entity)
    {
        var storageEntity = await this.motoAddDbContext.AddAsync(entity);

        return storageEntity.Entity;
    }

    public IQueryable<TEntity> SelectAllEntity() =>
        this.motoAddDbContext.Set<TEntity>()
        .AsNoTracking();

    public async ValueTask<TEntity> SelectEntityByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes)
    {
        var storageEntity = this.SelectAllEntity();

        foreach(var include in includes)
        {
            storageEntity = storageEntity.Include(include);
        }

        return await storageEntity.FirstOrDefaultAsync(expression);
    }

    public async ValueTask<TEntity> SelectEntityByIdAsync(TKey key)
    {
        return await this.motoAddDbContext.Set<TEntity>().FindAsync(key);
    }

    public async ValueTask<TEntity> UpdateEntityAsync(TEntity entity)
    {
        var updatedEntity = this.motoAddDbContext.Update<TEntity>(entity);

        return updatedEntity.Entity;

    }
    public async ValueTask<TEntity> DeleteEntityAsync(TEntity entity)
    {
        var deletedEntity = this.motoAddDbContext.Remove<TEntity>(entity);

        return deletedEntity.Entity;
    }
    public async ValueTask<int> SaveChangesAsync() =>
        await this.motoAddDbContext.SaveChangesAsync();
}
