using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesItems.DeleteSaleItem;

/// <summary>
/// Handler for processing DeleteItemCommand requests
/// </summary>
public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, DeleteSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository</param>
    /// <param name="mediator">The mediator used to dispatch events within the application.</param>
    public DeleteSaleItemHandler(ISaleItemRepository saleItemRepository, IMediator mediator)
    {
        _saleItemRepository = saleItemRepository;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="request">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleItemResult> Handle(DeleteSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleItem = await _saleItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (saleItem is null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        await _saleItemRepository.DeleteAsync(request.Id, cancellationToken);
        await _mediator.Publish(new SaleItemCanceledEvent(saleItem), cancellationToken);
        return new DeleteSaleItemResult { Success = true };
    }
}