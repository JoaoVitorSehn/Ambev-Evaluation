using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
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
    public List<SaleItem> SaleItems { get; set; } = new();

    /// <summary>
    /// Gets the current status of the sale. Initializes with active status.
    /// </summary>
    public SaleStatus Status { get; private set; }

    /// <summary>
    /// Gets the total amount of the sale, calculated as the sum of all sale item totals.
    /// </summary>
    public decimal TotalAmount => SaleItems.Sum(i => i.TotalItemAmount);

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        Status = SaleStatus.Active;
    }

    /// <summary>
    /// Cancel a sale.
    /// Changes the sale's status to Cancelled.
    /// </summary>
    public void CancelSale()
    {
        Status = SaleStatus.Canceled;
    }
}