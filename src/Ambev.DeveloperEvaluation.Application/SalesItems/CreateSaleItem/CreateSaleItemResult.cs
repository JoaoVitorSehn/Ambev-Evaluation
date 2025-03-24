namespace Ambev.DeveloperEvaluation.Application.SalesItems.CreateSaleItem
{
    /// <summary>
    /// Represents the response returned after successfully creating a new sale item.
    /// </summary>
    public class CreateSaleItemResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        public Guid SaleItemId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product associated with the sale item.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale item.
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
        /// Gets or sets the total amount for the sale item, after applying the discount.
        /// </summary>
        public decimal TotalItemAmount { get; set; }

        /// <summary>
        /// Gets or sets the sale ID to which the item belongs.
        /// </summary>
        public Guid SaleId { get; set; }
    }
}