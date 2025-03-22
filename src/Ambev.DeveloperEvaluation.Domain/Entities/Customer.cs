using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a customer in the system, responsible for making purchases.
/// This entity follows the External Identities pattern.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Gets the unique identifier of the customer from an external system.
    /// This ID is used to reference the customer without a direct relationship.
    /// </summary>
    public Guid ExternalId { get; private set; }

    /// <summary>
    /// Gets or sets the customer's full name.
    /// This value is denormalized for quick access and reporting purposes.
    /// </summary>
    public string Name { get; private set; } = String.Empty;

    /// <summary>
    /// Gets or sets the customer's email address.
    /// This value is stored for notification and contact purposes.
    /// </summary>
    public string Email { get; private set; } = String.Empty;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// This can be used for verification or customer support purposes.
    /// </summary>
    public string PhoneNumber { get; private set; } = String.Empty;

    /// <summary>
    /// Gets or sets the date when the customer was registered.
    /// This information is useful for tracking customer history.
    /// </summary>
    public DateTime RegisteredAt { get; private set; }
}