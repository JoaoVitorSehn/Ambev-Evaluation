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
            var isValid = saleItem.Validate(); 
            Assert.True(isValid.IsValid);
        }
    }
}