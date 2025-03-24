using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales
{
    /// <summary>
    /// Validator for ListSalesCommand
    /// </summary>
    public class ListSalesValidator : AbstractValidator<ListSalesCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListSalesValidator
        /// </summary>
        public ListSalesValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greather than 0");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("PageSize must be greather than 0");
        }
    }
}