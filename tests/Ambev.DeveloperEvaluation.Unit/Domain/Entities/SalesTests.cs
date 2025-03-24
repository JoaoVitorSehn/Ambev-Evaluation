using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that when a sale is marked as completed, its status changes to Completed.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to Completed when completed")]
    public void Given_ActiveSale_When_Completed_Then_StatusShouldBeCompleted()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Status = SaleStatus.Active;

        // Act
        sale.Complete();

        // Assert
        Assert.Equal(SaleStatus.Completed, sale.Status);
    }

    /// <summary>
    /// Tests that when a sale is marked as cancelled, its status changes to Cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to Cancelled when cancelled")]
    public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Status = SaleStatus.Active;

        // Act
        sale.Cancel();

        // Assert
        Assert.Equal(SaleStatus.Canceled, sale.Status);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = SaleTestData.GenerateInvalidSaleNumber(), // Invalid: non-numeric string
            SaleDate = SaleTestData.GenerateInvalidSaleDate(), // Invalid: future date
            Status = SaleTestData.GenerateInvalidSaleStatus(), // Invalid: non-existent status
        };

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}