using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
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

        /// <summary>
        /// Represents the sale this item belongs to.
        /// This property defines the relationship between the sale item and the sale entity.
        /// </summary>
        public Sale Sale { get; private set; }

        /// <summary>
        /// Calculates the total amount for the sale item, considering the unit price, quantity, and discount.
        /// Formula: (UnitPrice * Quantity) - Discount.
        /// </summary>
        public decimal TotalItemAmount => (UnitPrice * Quantity) - Discount;

        /// <summary>
        /// Applies a discount to the sale item based on the quantity of the product.
        /// - 10% discount for quantities between 4 and 9 items.
        /// - 20% discount for quantities between 10 and 20 items.
        /// No discount is applied for quantities less than 4 or greater than 20.
        /// </summary>
        public void ApplyDiscount()
        {
            if (Quantity >= 4 && Quantity < 10)
                Discount = (UnitPrice * Quantity) * 0.10m;
            else if (Quantity >= 10 && Quantity <= 20)
                Discount = (UnitPrice * Quantity) * 0.20m;
            else
                Discount = 0;
        }
    }
}