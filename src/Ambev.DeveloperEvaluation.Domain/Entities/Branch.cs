﻿using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a branch (store or location) where sales transactions occur.
/// This entity is responsible for storing essential branch information.
/// This entity follows the External Identities pattern.
/// </summary>
public class Branch : BaseEntity
{
    /// <summary>
    /// Gets the official name of the branch.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets the address of the branch.
    /// </summary>
    public string Address { get; set; } = String.Empty;

    /// <summary>
    /// Gets the city where the branch is located.
    /// </summary>
    public string City { get; set; } = String.Empty;

    /// <summary>
    /// Gets the state or region of the branch.
    /// </summary>
    public string State { get; set; } = String.Empty;

    /// <summary>
    /// Gets the country where the branch operates.
    /// </summary>
    public string Country { get; set; } = String.Empty;

    /// <summary>
    /// Gets the contact phone number for the branch.
    /// </summary>
    public string PhoneNumber { get; set; } = String.Empty;
}