using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// API response model for UpdateSale operation
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the branch where the sale was made.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the sale number, which uniquely identifies the sale transaction.
        /// </summary>
        public int SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale was created.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer associated with the sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the list of items included in the sale.
        /// </summary>
        public List<UpdateSaleItemResponse> SaleItems { get; set; } = new();

        /// <summary>
        /// Gets the current status of the sale. Initializes with active status.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the total amount of the sale, calculated as the sum of all sale item totals.
        /// </summary>
        public decimal TotalAmount => SaleItems.Sum(i => i.TotalItemAmount);
    }
}