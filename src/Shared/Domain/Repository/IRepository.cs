using System.Linq.Expressions;

namespace Rusell.Shared.Domain.Repository;

/// <summary>
/// Represents an entity repository.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TKey">Entity primary key type</typeparam>
public interface IRepository<TEntity, in TKey> where TEntity : class
{
    /// <summary>
    /// Save the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Save(TEntity entity);

    /// <summary>
    /// Find the entity entry by primary key.
    /// </summary>
    /// <param name="key">Entity entry identifier</param>
    /// <param name="noTracking">Either not to track the entity</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entry
    /// </returns>
    Task<TEntity> Find(TKey key, bool noTracking);

    /// <summary>
    /// Find the entity entry by primary key.
    /// </summary>
    /// <param name="key">Entity entry identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entry
    /// </returns>
    Task<TEntity> Find(TKey key);

    /// <summary>
    /// Determines whether any element oA function to test each element for a condition.f a sequence satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains true
    /// if any elements in the source sequence pass the test in the specified predicate;
    /// otherwise, false.
    /// </returns>
    Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Get all entity entries.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entries
    /// </returns>
    Task<IEnumerable<TEntity>> SearchAll();

    /// <summary>
    /// Delete the entity entry.
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Delete(TEntity entity);
}
