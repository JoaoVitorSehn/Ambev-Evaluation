using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the SaleItem entity class.
    /// Tests cover validation scenarios for SaleItem properties.
    /// </summary>
    public class SaleItemTests
    {
        /// <summary>
        /// Tests that a valid SaleItem is created with randomized values.
        /// </summary>
        [Fact(DisplayName = "SaleItem should be valid when all properties are correctly set")]
        public void Given_ValidSaleItemData_When_Created_Then_ShouldBeValid()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();

            // Act
            var isValid = saleItem.Validate(); // Assuming Validate() method exists

            // Assert
            Assert.True(isValid.IsValid);
        }

        /// <summary>
        /// Tests that validation fails when SaleItem has an invalid Product ID.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for SaleItem with invalid Product ID")]
        public void Given_SaleItemWithInvalidProductId_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductId = SaleItemTestData.GenerateInvalidProductId(),
                Quantity = SaleItemTestData.GenerateValidQuantity(),
                UnitPrice = SaleItemTestData.GenerateValidUnitPrice()
            };

            // Act
            var isValid = saleItem.Validate(); // Assuming Validate() method exists

            // Assert
            Assert.False(isValid.IsValid);
        }

        /// <summary>
        /// Tests that validation fails when SaleItem has an invalid Quantity.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for SaleItem with invalid Quantity")]
        public void Given_SaleItemWithInvalidQuantity_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductId = SaleItemTestData.GenerateValidProductId(),
                Quantity = SaleItemTestData.GenerateInvalidQuantity(),
                UnitPrice = SaleItemTestData.GenerateValidUnitPrice()
            };

            // Act
            var isValid = saleItem.Validate(); // Assuming Validate() method exists

            // Assert
            Assert.False(isValid.IsValid);
        }

        /// <summary>
        /// Tests that validation fails when SaleItem has an invalid Unit Price.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for SaleItem with invalid Unit Price")]
        public void Given_SaleItemWithInvalidUnitPrice_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductId = SaleItemTestData.GenerateValidProductId(),
                Quantity = SaleItemTestData.GenerateValidQuantity(),
                UnitPrice = SaleItemTestData.GenerateInvalidUnitPrice()
            };

            // Act
            var isValid = saleItem.Validate(); // Assuming Validate() method exists

            // Assert
            Assert.False(isValid.IsValid);
        }

        /// <summary>
        /// Tests that validation fails when SaleItem has an invalid Total Price.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for SaleItem with invalid Total Price")]
        public void Given_SaleItemWithInvalidTotalPrice_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductId = SaleItemTestData.GenerateValidProductId(),
                Quantity = SaleItemTestData.GenerateValidQuantity(),
                UnitPrice = SaleItemTestData.GenerateValidUnitPrice(),
                Discount = 999999
            };

            // Act
            var isValid = saleItem.Validate(); // Assuming Validate() method exists

            // Assert
            Assert.False(isValid.IsValid);
        }
    }
}