namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSaleItem
{
    /// <summary>
    /// Request model for deleting a sale item
    /// </summary>
    public class DeleteSaleItemRequest
    {
        /// <summary>
        /// The unique identifier of the sale item to delete
        /// </summary>
        public Guid Id { get; set; }
    }
}