using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSaleItem;

/// <summary>
/// Validator for GetSaleItemCommand
/// </summary>
public class GetSaleItemRequestValidator : AbstractValidator<GetSaleItemRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemCommand
    /// </summary>
    public GetSaleItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale item ID is required");
    }
}