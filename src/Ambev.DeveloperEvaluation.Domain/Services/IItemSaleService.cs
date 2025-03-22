using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    /// <summary>
    /// Interface for the service that handles operations related to sale items.
    /// It defines methods to perform various actions on sale items, such as applying discounts.
    /// </summary>s
    public interface IItemSaleService
    {
        /// <summary>
        /// Applies a discount to the given sale item after validating its quantity.
        /// This method ensures that the quantity is within the allowed limits before applying the discount.
        /// </summary>
        /// <param name="saleItem">The sale item on which the discount will be applied.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the quantity of the item exceeds the allowed limit for the sale.
        /// </exception>
        void ApplyDiscount(SaleItem saleItem);
    }
}