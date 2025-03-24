using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent : INotification
{
    public Guid SaleId { get; }
    public string SaleNumber { get; } = String.Empty;
    public DateTime ModifieddAt { get; }

    public SaleModifiedEvent(Sale sale)
    {
        SaleId = sale.Id;
        SaleNumber = sale.SaleNumber;
        ModifieddAt = DateTime.Now;
    }
}