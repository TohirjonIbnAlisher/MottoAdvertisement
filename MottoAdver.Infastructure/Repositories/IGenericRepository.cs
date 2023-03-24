using System.Linq.Expressions;

namespace MotoAdd.Infastructure.Repositories;

public interface IGenericRepository<TEntity, TKey> where TEntity : class
{
    ValueTask<TEntity> PostEntityAsync(TEntity entity);

    IQueryable<TEntity> SelectAllEntity();

    ValueTask<TEntity> SelectEntityByIdAsync(TKey key);

    ValueTask<TEntity> SelectEntityByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);

    ValueTask<TEntity> UpdateEntityAsync(TEntity entity);

    ValueTask<TEntity> DeleteEntityAsync(TEntity entity);
    ValueTask<int> SaveChangesAsync();
}
