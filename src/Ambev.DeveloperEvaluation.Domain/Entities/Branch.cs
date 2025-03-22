using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a branch (store or location) where sales transactions occur.
/// This entity is responsible for storing essential branch information.
/// </summary>
public class Branch : BaseEntity
{
    /// <summary>
    /// Gets the unique identifier for the branch.
    /// This ID is used as an external reference in other domains.
    /// </summary>
    public Guid BranchId { get; private set; }

    /// <summary>
    /// Gets the official name of the branch.
    /// </summary>
    public string Name { get; private set; } = String.Empty;

    /// <summary>
    /// Gets the address of the branch.
    /// </summary>
    public string Address { get; private set; } = String.Empty;

    /// <summary>
    /// Gets the city where the branch is located.
    /// </summary>
    public string City { get; private set; } = String.Empty;

    /// <summary>
    /// Gets the state or region of the branch.
    /// </summary>
    public string State { get; private set; } = String.Empty;

    /// <summary>
    /// Gets the country where the branch operates.
    /// </summary>
    public string Country { get; private set; } = String.Empty;

    /// <summary>
    /// Gets the contact phone number for the branch.
    /// </summary>
    public string PhoneNumber { get; private set; } = String.Empty;
}