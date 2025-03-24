using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Commom;

/// <summary>
/// Generic repository interface that defines common data access operations
/// using Entity Framework Core. Provides a standardized way to interact
/// with the database for any entity type, ensuring consistency and reusability.
/// </summary>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DefaultContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DefaultContext dbContext)
    {
        _context = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    /// <summary>
    /// Creates a new entity in the database
    /// </summary>
    /// <param name="entity">The entity to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created entity</returns>
    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Retrieves a entity by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="paths">Navigation properties to include in the query</param>
    /// <returns>The entity if found, null otherwise</returns>
    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params string[] paths)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();

        foreach (string path in paths)
            query = query.Include(path);

        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a entity from the database
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the entity was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing entity in the database
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated entity</returns>
    public virtual async Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await GetByIdAsync(entity.Id, cancellationToken);

        if (existingEntity == null)
            return null;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return existingEntity;
    }

    /// <summary>
    /// Retrieves a paginated list of entities from the database
    /// </summary>
    /// <param name="pageNumber">Page number (starting from 1)</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="cancellationToken">Cancellation token to allow the operation to be canceled</param>
    /// <param name="paths">Navigation properties to include in the query (optional)</param>
    /// <returns>A paginated queryable collection of entities</returns>
    public virtual async Task<(IQueryable<TEntity> Sales, int Count)> GetAsync(int pageNumber,
                                                                               int pageSize,
                                                                               CancellationToken cancellationToken = default,
                                                                               params string[] paths)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();

        foreach (string path in paths)
        {
            query = query.Include(path);
        }

        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        int count = await query.CountAsync();
        return (query.AsNoTracking(), count);
    }
}