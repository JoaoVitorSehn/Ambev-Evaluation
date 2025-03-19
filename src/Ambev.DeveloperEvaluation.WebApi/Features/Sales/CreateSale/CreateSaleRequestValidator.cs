using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleRequestValidator"/> class with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleDate: Cannot be null and must be a valid date.
        /// - BranchId: Cannot be empty.
        /// - SaleNumber: Must be greater than zero.
        /// - CustomerId: Cannot be empty.
        /// - SaleItems: Cannot be empty.
        /// </remarks>
        public CreateSaleRequestValidator()
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
                .GreaterThan(0)
                .WithMessage("Sale number must be greater than zero.");

            RuleFor(sale => sale.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            RuleFor(sale => sale.SaleItems)
                .NotEmpty()
                .WithMessage("The sale must contain at least one item.");
        }
    }
}