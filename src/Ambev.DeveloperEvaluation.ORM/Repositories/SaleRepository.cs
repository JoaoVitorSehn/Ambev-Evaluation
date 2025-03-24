using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Commom;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="dbContext">The database context</param>
        public SaleRepository(DefaultContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Retrieves a sale by their number
        /// </summary>
        /// <param name="saleNumber">The sale number to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetbySaleNumber(int saleNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .FirstOrDefaultAsync(u => u.SaleNumber == saleNumber, cancellationToken);
        }
    }
}