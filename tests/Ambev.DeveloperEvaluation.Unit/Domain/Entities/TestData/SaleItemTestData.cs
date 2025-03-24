using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for the <see cref="SaleItem"/> entity using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleItemTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated sale items will have valid:
    /// - Product ID
    /// - Quantity
    /// - Unit Price
    /// - Total Price
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(si => si.Id, f => Guid.NewGuid())
        .RuleFor(si => si.ProductId, f => Guid.NewGuid()) // Generate a random Product ID
        .RuleFor(si => si.Quantity, f => f.Random.Int(1, 10)) // Random quantity between 1 and 10
        .RuleFor(si => si.UnitPrice, f => f.Finance.Amount(10, 100)); // Random unit price between 10 and 100

    /// <summary>
    /// Generates a valid SaleItem entity with randomized data.
    /// The generated sale item will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItem entity with randomly generated data.</returns>
    public static SaleItem GenerateValidSaleItem()
    {
        return SaleItemFaker.Generate();
    }

    /// <summary>
    /// Generates a valid product ID.
    /// This ID is typically used to identify the product in the sale item.
    /// </summary>
    /// <returns>A valid product ID.</returns>
    public static Guid GenerateValidProductId()
    {
        return Guid.NewGuid(); // Generate a random product ID
    }

    /// <summary>
    /// Generates a valid quantity for the sale item.
    /// The generated quantity will be an integer between 1 and 10.
    /// </summary>
    /// <returns>A valid quantity for the sale item.</returns>
    public static int GenerateValidQuantity()
    {
        return new Faker().Random.Int(1, 10); // Quantity between 1 and 10
    }

    /// <summary>
    /// Generates a valid unit price for the sale item.
    /// The generated unit price will be a decimal value between 10 and 100.
    /// </summary>
    /// <returns>A valid unit price for the sale item.</returns>
    public static decimal GenerateValidUnitPrice()
    {
        return new Faker().Finance.Amount(10, 100); // Unit price between 10 and 100
    }

    /// <summary>
    /// Generates a valid total price for the sale item.
    /// The total price will be calculated as quantity multiplied by unit price.
    /// </summary>
    /// <returns>A valid total price for the sale item.</returns>
    public static decimal GenerateValidTotalPrice()
    {
        int quantity = GenerateValidQuantity();
        decimal unitPrice = GenerateValidUnitPrice();
        return quantity * unitPrice; // Total price = Quantity * Unit Price
    }

    /// <summary>
    /// Generates an invalid product ID for testing negative scenarios.
    /// The generated product ID will:
    /// - Be an empty GUID
    /// </summary>
    /// <returns>An invalid product ID.</returns>
    public static Guid GenerateInvalidProductId()
    {
        return Guid.Empty; // Empty GUID as an invalid product ID
    }

    /// <summary>
    /// Generates an invalid quantity for the sale item.
    /// The generated quantity will:
    /// - Be zero or negative (invalid quantity for a sale item)
    /// </summary>
    /// <returns>An invalid quantity for the sale item.</returns>
    public static int GenerateInvalidQuantity()
    {
        return new Faker().Random.Int(-10, 0); // Invalid quantity (negative or zero)
    }

    /// <summary>
    /// Generates an invalid unit price for the sale item.
    /// The generated unit price will:
    /// - Be a negative value (invalid unit price for a sale item)
    /// </summary>
    /// <returns>An invalid unit price for the sale item.</returns>
    public static decimal GenerateInvalidUnitPrice()
    {
        return new Faker().Random.Number(-100, -1); // Invalid negative unit price
    }

    /// <summary>
    /// Generates an invalid total price for the sale item.
    /// The total price will:
    /// - Be calculated using invalid quantity or unit price
    /// </summary>
    /// <returns>An invalid total price for the sale item.</returns>
    public static decimal GenerateInvalidTotalPrice()
    {
        int quantity = GenerateInvalidQuantity();
        decimal unitPrice = GenerateInvalidUnitPrice();
        return quantity * unitPrice; // Invalid total price
    }
}