using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesItems.UpdateSaleItem;

/// <summary>
/// Validator for UpdateSaleItemCommand
/// </summary>
public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public UpdateSaleItemValidator()
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
            .LessThanOrEqualTo(x => x.UnitPrice).WithMessage("Discount cannot be greater than unit price.");

        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("Sale Id is required.");
    }
}