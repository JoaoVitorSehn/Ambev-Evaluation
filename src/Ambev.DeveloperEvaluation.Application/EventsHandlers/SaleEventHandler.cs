using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Events.Handlers;

public class SaleEventHandler : INotificationHandler<SaleCreatedEvent>,
    INotificationHandler<SaleModifiedEvent>,
    INotificationHandler<SaleCanceledEvent>,
    INotificationHandler<SaleItemCanceledEvent>
{
    private readonly ILogger<SaleEventHandler> _logger;

    public SaleEventHandler(ILogger<SaleEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[EVENT] Sale Created: {notification.SaleNumber} at {notification.CreatedAt}");
        return Task.CompletedTask;
    }

    public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[EVENT] Sale Modified: {notification.SaleNumber} at {notification.ModifieddAt}");
        return Task.CompletedTask;
    }

    public Task Handle(SaleCanceledEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[EVENT] Sale Cancelled: {notification.SaleNumber} at {notification.CanceleddAt}");
        return Task.CompletedTask;
    }

    public Task Handle(SaleItemCanceledEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[EVENT] Item Cancelled: Item {notification.ItemId} at {notification.CanceledAt}");
        return Task.CompletedTask;
    }
}