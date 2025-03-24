using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleItemCanceledEvent : INotification
{
    public Guid SaleId { get; }
    public DateTime CanceledAt { get; }
    public Guid ItemId { get; }

    public SaleItemCanceledEvent(SaleItem saleItem)
    {
        SaleId = saleItem.Sale.Id;
        CanceledAt = DateTime.Now;
        ItemId = saleItem.Id;
    }
}