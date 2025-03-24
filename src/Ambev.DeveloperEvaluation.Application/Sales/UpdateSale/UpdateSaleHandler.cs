using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="mediator">The mediator used to dispatch events within the application.</param>
    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the update of an existing sale. This method processes the update command for a sale by performing validation, retrieving the sale from the repository,
    /// applying the necessary changes, and returning the result.
    /// </summary>
    /// <param name="request">The command containing the sale data to be updated, including the sale's identifier, new values, and sale items to be modified.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests during the execution of the method.</param>
    /// <returns>A Task containing the result of the update operation, which includes the updated sale details in the form of an <see cref="UpdateSaleResult"/>.</returns>
    /// <exception cref="ValidationException">Thrown if the command data does not meet the required validation rules.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the sale with the specified ID cannot be found in the repository.</exception>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken, "SaleItems");

        if (sale is null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        var saleSpecification = new CanceledSaleSpecification();

        if (saleSpecification.IsSatisfiedBy(sale))
            throw new InvalidOperationException($"Sale with ID {request.Id} is already cancelled and cannot be updated.");

        if (request.Status == SaleStatus.Canceled)
            await _mediator.Publish(new SaleCanceledEvent(sale), cancellationToken);

        sale.SaleDate = request.SaleDate;
        sale.BranchId = request.BranchId;
        sale.SaleNumber = request.SaleNumber;
        sale.CustomerId = request.CustomerId;
        sale.Status = request.Status;
        await _saleRepository.UpdateAsync(sale, cancellationToken);
        await _mediator.Publish(new SaleModifiedEvent(sale), cancellationToken);
        return _mapper.Map<UpdateSaleResult>(sale);
    }
}