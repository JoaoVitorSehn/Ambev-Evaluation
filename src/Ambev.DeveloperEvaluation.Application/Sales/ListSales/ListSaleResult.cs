using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class ListSaleResult
{
    /// <summary>
    /// Gets or sets the total count of sales
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the list of sales results
    /// </summary>
    public IEnumerable<GetSaleResult> Sales { get; set; }
}