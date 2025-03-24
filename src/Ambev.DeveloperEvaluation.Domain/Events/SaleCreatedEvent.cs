using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCreatedEvent : INotification
{
    public Guid SaleId { get; }
    public int SaleNumber { get; }
    public DateTime CreatedAt { get; }

    public SaleCreatedEvent(Sale sale)
    {
        SaleId = sale.Id;
        SaleNumber = sale.SaleNumber;
        CreatedAt = sale.SaleDate;
    }
}