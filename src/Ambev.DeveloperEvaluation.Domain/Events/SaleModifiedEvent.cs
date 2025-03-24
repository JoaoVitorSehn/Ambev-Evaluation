using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent : INotification
{
    public Guid SaleId { get; }
    public int SaleNumber { get; }
    public DateTime ModifieddAt { get; }

    public SaleModifiedEvent(Sale sale)
    {
        SaleId = sale.Id;
        SaleNumber = sale.SaleNumber;
        ModifieddAt = DateTime.Now;
    }
}