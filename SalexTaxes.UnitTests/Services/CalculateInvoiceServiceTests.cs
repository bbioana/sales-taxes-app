using FluentAssertions;
using SalesTaxes.Data.Services;
using Xunit;

namespace SalesTaxes.UnitTests.Services
{
    public class CalculateInvoiceServiceTests
    {
        private readonly CalculateInvoiceService _sut = new();

        [Theory]
        [InlineData(2, 7.65)]
        [InlineData(3, 6.70)]
        public void CalculateTaxes_Should_Return_Corect_Taxes(int shoppingCartNo, decimal expectedSalesTaxes)
        {
            //Arrange
            var shoppingCart = shoppingCartNo == 2 ? MockedData.MockedData.SetUpShoppingCart2() : MockedData.MockedData.SetUpShoppingCart3();

            //Act
            var result = _sut.CalculateTaxes(shoppingCart);

            //Assert
            result.Should().Be(expectedSalesTaxes);
        }
    }
}
