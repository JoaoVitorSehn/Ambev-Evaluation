using Ambev.DeveloperEvaluation.Application.SalesItems.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the branch id.
    /// </summary>
    public Guid BranchId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the sale number. Must be unique.
    /// </summary>
    public string SaleNumber { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the sale date. Must be greater than or equal to today's date.
    /// </summary>
    public DateTime SaleDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    public Guid CustomerId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the list of sale items. Must contain at least one item.
    /// </summary>
    public List<CreateSaleItemCommand> SaleItems { get; set; } = new();
}