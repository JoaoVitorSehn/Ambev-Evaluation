using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    /// <summary>
    /// The <see cref="ItemSaleService"/> class is responsible for handling operations related
    /// to sale items, such as applying business rules (e.g., discount application) and validations.
    /// </summary>
    public class ItemSaleService : IItemSaleService
    {
        /// <summary>
        /// Applies the discount to a given sale item after validating its quantity.
        /// This method ensures that the quantity of items is within allowed limits before 
        /// applying any discount.
        /// </summary>
        /// <param name="saleItem">The sale item on which the discount will be applied.</param>
        /// <exception cref="DomainException">
        /// Thrown if the quantity of the item exceeds the allowed limit for the sale.
        /// </exception>
        public void ApplyDiscount(SaleItem saleItem)
        {
            saleItem.ValidateQuantity();
            saleItem.ApplyDiscount();
        }
    }
}