namespace Ambev.DeveloperEvaluation.Application.SalesItems.GetSaleItem;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleItemResult
{
    /// <summary>
    /// Represents the unique identifier of the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Represents the quantity of the product in the sale item.
    /// The quantity must be greater than zero to be valid.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Represents the unit price of the product in the sale item.
    /// The unit price is used to calculate the total price of the item before any discounts.
    /// </summary>
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// Represents the discount applied to the sale item, if any.
    /// This is calculated based on the quantity of the product.
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Represents the unique identifier of the sale that this item is part of.
    /// It is a foreign key linking the sale item to a specific sale.
    /// </summary>
    public Guid SaleId { get; private set; }
}