using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCanceledEvent : INotification
{
    public Guid SaleId { get; }
    public int SaleNumber { get; }
    public DateTime CanceleddAt { get; }

    public SaleCanceledEvent(Sale sale)
    {
        SaleId = sale.Id;
        SaleNumber = sale.SaleNumber;
        CanceleddAt = DateTime.Now;
    }
}