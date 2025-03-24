using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSaleItem;

/// <summary>
/// Represents a request to update a sale item.
/// </summary>
public class UpdateSaleItemRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale item to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in the sale item.
    /// The quantity must be greater than zero to be valid.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in the sale item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the sale item, if any.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the sale this item belongs to.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the current status of the sale item. Initializes with active status.
    /// </summary>
    public SaleItemStatus Status { get; set; }
}