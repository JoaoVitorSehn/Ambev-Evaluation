using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleValidator"/> class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleDate: Cannot be null.
    /// - BranchId: Cannot be empty.
    /// - SaleNumber: Must be greater than zero.
    /// - SaleStatus: Cannot update a canceled sale.
    /// - CustomerId: Cannot be empty.
    /// - SaleItems: Cannot be empty.
    /// </remarks>
    public UpdateSaleValidator()
    {
        RuleFor(sale => sale.SaleDate)
            .NotNull()
            .WithMessage("The sale date is required.");

        RuleFor(sale => sale.BranchId)
            .NotEmpty()
            .WithMessage("Branch ID is required.");

        RuleFor(sale => sale.SaleNumber)
            .NotEmpty();

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

        RuleFor(sale => sale.SaleItems)
            .NotEmpty()
            .WithMessage("The sale must contain at least one item.");

        RuleFor(sale => sale.Status)
            .NotEqual(SaleStatus.Canceled)
            .WithMessage("Cannot update a canceled sale.");

        RuleForEach(sale => sale.SaleItems)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId)
                    .NotEmpty()
                    .WithMessage("Each sale item must have a product ID.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Each sale item must have a quantity greater than zero.");

                item.RuleFor(i => i.UnitPrice)
                    .GreaterThan(0)
                    .WithMessage("Each sale item must have a valid unit price.");

                item.RuleFor(i => i.Quantity)
                    .LessThanOrEqualTo(20)
                    .WithMessage("Cannot sell more than 20 identical items.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThanOrEqualTo(4)
                    .When(i => i.Quantity <= 20)
                    .WithMessage("Purchases below 4 items cannot have a discount.");

                item.RuleFor(i => i.Quantity)
                    .LessThan(4)
                    .When(i => i.Quantity > 20)
                    .WithMessage("Cannot sell more than 20 identical items.");

                item.RuleFor(x => x.Discount)
                    .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                    .LessThanOrEqualTo(x => x.UnitPrice * x.Quantity).WithMessage("Discount cannot be greater than the total price.");
            });
    }
}