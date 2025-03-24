using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCanceledEvent : INotification
{
    public Guid SaleId { get; }
    public string SaleNumber { get; } = String.Empty;
    public DateTime CanceleddAt { get; }

    public SaleCanceledEvent(Sale sale)
    {
        SaleId = sale.Id;
        SaleNumber = sale.SaleNumber;
        CanceleddAt = DateTime.Now;
    }
}