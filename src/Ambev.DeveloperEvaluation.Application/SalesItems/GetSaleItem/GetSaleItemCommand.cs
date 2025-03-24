using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesItems.GetSaleItem;

/// <summary>
/// Command for retrieving a sale item by their ID
/// </summary>
public class GetSaleItemCommand : IRequest<GetSaleItemResult>
{
    /// <summary>
    /// The unique identifier of the sale item to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetUserCommand
    /// </summary>
    /// <param name="id">The ID of the sale item to retrieve</param>
    public GetSaleItemCommand(Guid id)
    {
        Id = id;
    }
}