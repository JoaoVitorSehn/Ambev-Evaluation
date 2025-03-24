using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// The SaleItem class is a domain entity that represents an individual item within a sale transaction. 
/// It encapsulates the core business rules related to the pricing, quantity, discount, and total amount 
/// of the item in a sale.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Represents the unique identifier of the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Represents the quantity of the product in the sale item.
    /// The quantity must be greater than zero to be valid.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Represents the unit price of the product in the sale item.
    /// The unit price is used to calculate the total price of the item before any discounts.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Represents the discount applied to the sale item, if any.
    /// This is calculated based on the quantity of the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Represents the unique identifier of the sale that this item is part of.
    /// It is a foreign key linking the sale item to a specific sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Represents the sale this item belongs to.
    /// This property defines the relationship between the sale item and the sale entity.
    /// </summary>
    public Sale Sale { get; set; }

    /// <summary>
    /// Calculates the total amount for the sale item, considering the unit price, quantity, and discount.
    /// Formula: (UnitPrice * Quantity) - Discount.
    /// </summary>
    public decimal TotalItemAmount => (UnitPrice * Quantity) - Discount;

    /// <summary>
    /// Gets the current status of the sale item. Initializes with active status.
    /// </summary>
    public SaleItemStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the product associated with the sale item. This represents the specific product 
    /// that is being sold as part of the sale item, including its details such as name, price, etc.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem()
    {
        Status = SaleItemStatus.Active;
    }

    /// <summary>
    /// Validates the sale item using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Applies a discount to the sale item based on the quantity of the product.
    /// - 10% discount for quantities between 4 and 9 items.
    /// - 20% discount for quantities between 10 and 20 items.
    /// No discount is applied for quantities less than 4 or greater than 20.
    /// </summary>
    public void ApplyDiscount()
    {
        if (Quantity >= 4 && Quantity < 10)
        {
            Discount = (Quantity * UnitPrice) * 0.10m;
        }
        else if (Quantity >= 10 && Quantity <= 20)
        {
            Discount = (Quantity * UnitPrice) * 0.20m;
        }
        else if (Quantity < 4)
        {
            Discount = 0;
        }
    }

    /// <summary>
    /// Validates the quantity of items to ensure that the number of units for a product
    /// does not exceed the maximum limit of 20 items per sale.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the quantity of items exceeds 20.
    /// </exception>
    public void ValidateQuantity()
    {
        if (Quantity > 20)
        {
            throw new DomainException("It is not possible to sell more than 20 items.");
        }
    }
}