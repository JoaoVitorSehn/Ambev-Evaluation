using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// The Sale class is a core domain entity that encapsulates the behavior and business rules 
/// associated with a sales transaction. It ensures that sales are managed consistently, 
/// maintaining integrity and enforcing business logic.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the branch where the sale was made.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets or sets the sale number, which uniquely identifies the sale transaction.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

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
    public SaleStatus Status { get; set; }

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
    /// Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Sale Number format</list>
    /// <list type="bullet">Sale Date is not in the future</list>
    /// <list type="bullet">Total Amount is greater than zero</list>
    /// <list type="bullet">Product list is not empty</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Cancel a sale.
    /// Changes the sale's status to Cancelled.
    /// </summary>
    public void Cancel()
    {
        Status = SaleStatus.Canceled;
    }

    /// <summary>
    /// Complete a sale.
    /// Changes the sale's status to Completed.
    /// </summary>
    public void Complete()
    {
        Status = SaleStatus.Completed;
    }
}