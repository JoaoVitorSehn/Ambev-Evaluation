using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesItems.DeleteSaleItem;

/// <summary>
/// Validator for DeleteSaleItemCommand
/// </summary>
public class DeleteSaleItemValidator : AbstractValidator<DeleteSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleItemCommand
    /// </summary>
    public DeleteSaleItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale item ID is required");
    }
}