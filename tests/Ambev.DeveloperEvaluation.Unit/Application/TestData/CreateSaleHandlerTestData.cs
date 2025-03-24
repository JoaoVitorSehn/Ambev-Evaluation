using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.SalesItems.CreateSaleItem;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;
/// <summary>
/// Provides methods for generating test data using the Bogus library for Sale and SaleItem entities.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.SaleNumber, f => f.Commerce.Ean13()) // Generate a valid sale number as EAN-13 string
        .RuleFor(s => s.SaleDate, f => f.Date.Past(1)) // Sale date within the last year
        .RuleFor(s => s.BranchId, f => f.Random.Guid()) // Random BranchId
        .RuleFor(s => s.CustomerId, f => f.Random.Guid()) // Random CustomerId
        .RuleFor(s => s.SaleItems, f => GenerateSaleItems(f)); // Generate Sale Items

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
            Discount = 0, // Will apply the discount logic below
        }).Select(item =>
        {
            // Apply discount logic for SaleItem based on the quantity
            decimal totalAmount = item.Quantity * item.UnitPrice;

            if (item.Quantity >= 4 && item.Quantity < 10)
            {
                // Apply 10% discount, but ensure it doesn't exceed the total amount
                item.Discount = totalAmount * 0.10m;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                // Apply 20% discount, but ensure it doesn't exceed the total amount
                item.Discount = totalAmount * 0.20m;
            }

            // Ensure that the discount is never greater than the total amount
            item.Discount = Math.Min(item.Discount, totalAmount);

            // Ensure that the discount is never greater than the unit price multiplied by quantity
            item.Discount = Math.Min(item.Discount, item.UnitPrice * item.Quantity);

            return item;
        }).ToList();
    }

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidSaleCommand()
    {
        return createSaleHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a list of Sale entities for testing purposes.
    /// </summary>
    /// <param name="count">The number of Sale entities to generate.</param>
    /// <returns>A list of Sale entities.</returns>
    public static List<CreateSaleCommand> GenerateSaleCommands(int count)
    {
        return createSaleHandlerFaker.Generate(count);
    }
}