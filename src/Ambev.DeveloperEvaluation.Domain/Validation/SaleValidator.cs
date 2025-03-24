using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for the Sale entity using FluentValidation.
    /// </summary>
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.SaleNumber).NotEmpty().WithMessage("Sale number is required.");
            RuleFor(x => x.SaleNumber).Matches(@"^\d+$").WithMessage("Sale number must be numeric.");
            RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale date is required.");
            RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Sale date cannot be in the future.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than zero.");
        }
    }
}