using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Command for retrieving a sale list
/// </summary>
public class ListSalesCommand : IRequest<ListSaleResult>
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