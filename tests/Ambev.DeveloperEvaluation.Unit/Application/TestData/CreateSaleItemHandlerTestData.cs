using Ambev.DeveloperEvaluation.Application.SalesItems.CreateSaleItem;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library for SaleItem entities.
/// </summary>
public static class CreateSaleItemHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// </summary>
    private static readonly Faker<CreateSaleItemCommand> createSaleItemHandlerFaker = new Faker<CreateSaleItemCommand>()
        .RuleFor(s => s.ProductId, f => f.Random.Guid()) // Random ProductId
        .RuleFor(s => s.Quantity, f => f.Random.Int(1, 20)) // Random Quantity
        .RuleFor(s => s.UnitPrice, f => f.Finance.Amount(10, 1000)) // Random Unit Price
        .RuleFor(s => s.Discount, f => 0) // Discount will be calculated based on quantity
        .RuleFor(s => s.SaleId, f => f.Random.Guid()); // Random SaleId

    /// <summary>
    /// Generates a list of SaleItems with randomized data.
    /// </summary>
    /// <param name="f">The Faker instance used to generate random data.</param>
    /// <returns>A list of SaleItems with randomized values for product, quantity, unit price, and discount.</returns>
    private static List<CreateSaleItemCommand> GenerateSaleItems(Faker f)
    {
        return f.Make(3, () => new CreateSaleItemCommand
        {
            ProductId = f.Random.Guid(), // Random ProductId
            Quantity = f.Random.Int(1, 20), // Random quantity
            UnitPrice = f.Finance.Amount(10, 1000), // Random unit price
            Discount = 0, // Discount will be calculated based on the logic below
            SaleId = f.Random.Guid(), // Random SaleId
        }).Select(item =>
        {
            // Apply discount logic for SaleItem based on the quantity
            decimal totalAmount = item.Quantity * item.UnitPrice;

            if (item.Quantity >= 4 && item.Quantity < 10)
            {
                item.Discount = totalAmount * 0.10m;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                item.Discount = totalAmount * 0.20m;
            }

            // Ensure that the discount is never greater than the total amount
            item.Discount = Math.Min(item.Discount, totalAmount);

            return item;
        }).ToList();
    }

    /// <summary>
    /// Generates a valid SaleItem entity with randomized data.
    /// </summary>
    /// <returns>A valid SaleItem entity with randomly generated data.</returns>
    public static CreateSaleItemCommand GenerateValidSaleItemCommand()
    {
        return createSaleItemHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a list of SaleItem entities for testing purposes.
    /// </summary>
    /// <param name="count">The number of SaleItem entities to generate.</param>
    /// <returns>A list of SaleItem entities.</returns>
    public static List<CreateSaleItemCommand> GenerateSaleItemCommands(int count)
    {
        return createSaleItemHandlerFaker.Generate(count);
    }
}