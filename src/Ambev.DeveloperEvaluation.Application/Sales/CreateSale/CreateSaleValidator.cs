using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleValidator"/> class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleDate: Cannot be null and must be a valid date.
    /// - BranchId: Cannot be empty.
    /// - SaleNumber: Must be greater than zero.
    /// - CustomerId: Cannot be empty.
    /// - SaleItems: Cannot be empty.
    /// </remarks>
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.SaleDate)
            .NotNull()
            .WithMessage("The sale date is required.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("The sale date cannot be in the future.");

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

                item.RuleFor(x => x.Discount)
                    .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                    .LessThanOrEqualTo(x => x.UnitPrice * x.Quantity).WithMessage("Discount cannot be greater than the total price.");
            });
    }
}