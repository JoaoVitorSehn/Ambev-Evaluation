namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Request model for listing sales with pagination
/// </summary>
public class ListSalesRequest
{
    /// <summary>
    /// The page number to retrieve
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The number of items per page
    /// </summary>
    public int PageSize { get; set; }
}