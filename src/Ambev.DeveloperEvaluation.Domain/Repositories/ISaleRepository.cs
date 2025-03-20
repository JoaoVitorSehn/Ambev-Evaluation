using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for User entity operations
    /// </summary>
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        /// <summary>
        /// Retrieves a sale by their number
        /// </summary>
        /// <param name="saleNumber">The sale number to search for</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetbySaleNumber(int saleNumber, CancellationToken cancellationToken = default);
    }
}