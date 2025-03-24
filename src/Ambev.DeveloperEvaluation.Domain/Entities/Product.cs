using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product available for sale in the system.
/// This entity holds the product's essential information.
/// This entity follows the External Identities pattern.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the category of the product (e.g., electronics, clothing, etc.).
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the stock quantity available for the product.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets the supplier of the product.
    /// </summary>
    public string Supplier { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's unique identifier in the inventory system.
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;
}