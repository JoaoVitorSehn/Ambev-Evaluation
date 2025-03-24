namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Creates a new entity in the repository
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created entity</returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a entity by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="paths">Navigation properties to include in the query</param>
        /// <returns>The entity if found, null otherwise</returns>
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params string[] paths);

        /// <summary>
        /// Deletes a entity from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the entity was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity in the database
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated entity</returns>
        Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of entities from the database
        /// </summary>
        /// <param name="pageNumber">Page number (starting from 1)</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <param name="cancellationToken">Cancellation token to allow the operation to be canceled</param>
        /// <param name="paths">Navigation properties to include in the query (optional)</param>
        /// <returns>A paginated queryable collection of entities</returns>
        Task<(IQueryable<T> Sales, int Count)> GetAsync(int pageNumber,
                                                        int pageSize,
                                                        CancellationToken cancellationToken = default,
                                                        params string[] paths);
    }
}