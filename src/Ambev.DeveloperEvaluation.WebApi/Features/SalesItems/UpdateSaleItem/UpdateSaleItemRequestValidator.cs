using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSaleItem;

/// <summary>
/// Validator for UpdateSaleItemRequest
/// </summary>
public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleItemRequestValidator"/> class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Id: Cannot be null.
    /// - ProductId: Is required.
    /// - Quantity: Must be greater than zero.
    /// - UnitPrice: Must be greater than zero.
    /// - Discount: Must be not negative and greater than unit price.
    /// - SaleId: Is required.
    /// </remarks>
    public UpdateSaleItemRequestValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Sale item Id is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product Id is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero.");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
            .LessThanOrEqualTo(x => x.UnitPrice * x.Quantity).WithMessage("Discount cannot be greater than the total price.");

        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("Sale Id is required.");
    }
}