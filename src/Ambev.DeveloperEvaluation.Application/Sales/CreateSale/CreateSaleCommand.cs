using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public record CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the branch.
        /// </summary>
        public Guid BranchId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the sale number.
        /// </summary>
        public int SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime SaleDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public Guid CustomerId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        public List<SaleItem> SaleItems { get; set; } = new();

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}