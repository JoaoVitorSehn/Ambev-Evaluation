using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class CanceledSaleItemSpecification : ISpecification<SaleItem>
{
    public bool IsSatisfiedBy(SaleItem saleItem)
    {
        return saleItem.Status == SaleItemStatus.Canceled;
    }
}