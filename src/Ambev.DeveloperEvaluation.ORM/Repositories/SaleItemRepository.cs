using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Commom;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository : BaseRepository<SaleItem>, ISaleItemRepository
{
    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="dbContext">The database context</param>
    public SaleItemRepository(DefaultContext dbContext) : base(dbContext)
    {
    }
}