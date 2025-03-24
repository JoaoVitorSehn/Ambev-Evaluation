using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesItems.UpdateSaleItem;

/// <summary>
/// Handler for processing UpdateSaleItemCommand requests
/// </summary>
public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly ISaleItemService _service;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of UpdateSaleItemHandler
    /// </summary>
    /// <param name="saleItemRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="mediator">The mediator used to dispatch events within the application.</param>
    public UpdateSaleItemHandler(ISaleItemRepository saleItemRepository,
                                 IMapper mapper,
                                 ISaleItemService itemService,
                                 IMediator mediator)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
        _service = itemService;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the update of an existing sale item. This method processes the update command for a sale item by performing validation, retrieving the sale from the repository,
    /// applying the necessary changes, and returning the result.
    /// </summary>
    /// <param name="request">The command containing the sale item data to be updated, including the sale's item identifier.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests during the execution of the method.</param>
    /// <returns>A Task containing the result of the update operation, which includes the updated sale item details in the form of an <see cref="UpdateSaleResult"/>.</returns>
    /// <exception cref="ValidationException">Thrown if the command data does not meet the required validation rules.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the sale item with the specified ID cannot be found in the repository.</exception>
    public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleItem = await _saleItemRepository.GetByIdAsync(request.Id, cancellationToken, "Sale");

        if (saleItem is null)
            throw new KeyNotFoundException($"Sale item with ID {request.Id} not found");

        var saleItemSpecification = new CanceledSaleItemSpecification();

        if (saleItemSpecification.IsSatisfiedBy(saleItem))
            throw new InvalidOperationException($"Sale item with ID {request.Id} is already cancelled and cannot be updated.");

        var saleSpecification = new CanceledSaleSpecification();

        if (saleSpecification.IsSatisfiedBy(saleItem.Sale))
            throw new InvalidOperationException($"Sale with ID {request.Id} is already cancelled and cannot be updated.");

        if (saleItem.Status == SaleItemStatus.Active && request.Status == SaleItemStatus.Canceled)
        {
            await _mediator.Publish(new SaleItemCanceledEvent(saleItem), cancellationToken);
        }

        saleItem.Status = request.Status;
        saleItem.Discount = request.Discount;
        saleItem.Quantity = request.Quantity;
        saleItem.UnitPrice = request.UnitPrice;
        _service.ApplyDiscount(saleItem);
        await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);
        return _mapper.Map<UpdateSaleItemResult>(saleItem);
    }
}