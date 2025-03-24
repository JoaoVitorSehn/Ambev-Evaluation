using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for the <see cref="Sale"/> entity using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated sales will have valid:
    /// - Sale Number
    /// - Sale Date
    /// - Status (Active, Cancelled, Completed, etc.)
    /// - Total Amount
    /// - Product(s)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.Id, f => Guid.NewGuid())
        .RuleFor(s => s.SaleNumber, f => f.Commerce.Ean13()) // Generate a random sale number (EAN-13 format)
        .RuleFor(s => s.SaleDate, f => f.Date.Past(1)) // Generate a random past date
        .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>()) // Randomly select sale status
        .RuleFor(s => s.TotalAmount, f => f.Finance.Amount(100, 1000)); // Random total amount between 100 and 1000

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }

    /// <summary>
    /// Generates a valid sale number in the format of EAN-13.
    /// This is typically used for sale identifiers.
    /// </summary>
    /// <returns>A valid sale number in EAN-13 format.</returns>
    public static string GenerateValidSaleNumber()
    {
        return new Faker().Commerce.Ean13();
    }

    /// <summary>
    /// Generates a valid sale date.
    /// The generated date will be in the past, representing an actual sale transaction.
    /// </summary>
    /// <returns>A valid sale date.</returns>
    public static DateTime GenerateValidSaleDate()
    {
        return new Faker().Date.Past(1); // Generate a random date in the past year
    }

    /// <summary>
    /// Generates a valid total amount for a sale.
    /// The generated amount will be a decimal value between 100 and 1000.
    /// </summary>
    /// <returns>A valid total amount for the sale.</returns>
    public static decimal GenerateValidTotalAmount()
    {
        return new Faker().Finance.Amount(100, 1000); // Amount between 100 and 1000
    }

    /// <summary>
    /// Generates a valid sale status.
    /// The generated status will randomly be Active, Cancelled, or Completed.
    /// </summary>
    /// <returns>A valid sale status.</returns>
    public static SaleStatus GenerateValidSaleStatus()
    {
        return new Faker().PickRandom<SaleStatus>(); // Randomly pick a sale status
    }

    /// <summary>
    /// Generates an invalid sale number for testing negative scenarios.
    /// The generated sale number will:
    /// - Be a non-numeric string
    /// - Not follow any valid sale identifier format
    /// </summary>
    /// <returns>An invalid sale number.</returns>
    public static string GenerateInvalidSaleNumber()
    {
        return new Faker().Lorem.Word(); // Generate a non-numeric word
    }

    /// <summary>
    /// Generates an invalid sale date for testing negative scenarios.
    /// The generated sale date will:
    /// - Be in the future, which makes it invalid for a sale that should have already occurred.
    /// </summary>
    /// <returns>An invalid future sale date.</returns>
    public static DateTime GenerateInvalidSaleDate()
    {
        return new Faker().Date.Future(); // Generate a future date
    }

    /// <summary>
    /// Generates an invalid total amount for a sale.
    /// The generated amount will:
    /// - Be a negative value (invalid for a sale)
    /// </summary>
    /// <returns>An invalid negative total amount for the sale.</returns>
    public static decimal GenerateInvalidTotalAmount()
    {
        return new Faker().Random.Number(-1000, -1); // Invalid negative amount
    }

    /// <summary>
    /// Generates an invalid sale status for testing negative scenarios.
    /// The generated status will:
    /// - Not be a valid enum value for SaleStatus
    /// </summary>
    /// <returns>An invalid sale status.</returns>
    public static SaleStatus GenerateInvalidSaleStatus()
    {
        return (SaleStatus)(-1); // Invalid enum value
    }
}