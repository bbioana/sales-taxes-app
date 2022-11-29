using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using SalesTaxes.Data;
using SalesTaxes.Data.Interfaces;
using SalesTaxes.Data.Services;
using Xunit;

namespace SalesTaxes.UnitTests.Services
{
    public class ShoppingCartServiceTests
    {
        private readonly Mock<ICalculateInvoice> _calculateInvoiceMock = new();
        private readonly ShoppingCartService _sut;

        public ShoppingCartServiceTests()
        {
            _sut = new ShoppingCartService(_calculateInvoiceMock.Object);
        }

        [Fact]
        public async Task GetShoppingCartAsync_Should_Return_ShoppingCart1_When_Select_Option_1()
        {
            //Arrange
            var shoppingCartNo = 1;
            var expectedResult = MockedData.MockedData.SetUpShoppingCart1();

            // Act
            var result = await _sut.GetShoppingCartAsync(shoppingCartNo);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
            result.Products.Select(c => c.Name).Should().Equal(expectedResult.Products.Select(c => c.Name));
            result.Products.Select(c => c.Price).Should().Equal(expectedResult.Products.Select(c => c.Price));
            result.Products.Select(c => c.Quantity).Should().Equal(expectedResult.Products.Select(c => c.Quantity));
            result.Products.Select(c => c.IsImported).Should().Equal(expectedResult.Products.Select(c => c.IsImported));
            result.Products.Select(c => c.ProductType).Should().Equal(expectedResult.Products.Select(c => c.ProductType));
        }

        [Fact]
        public async Task GetShoppingCartAsync_Should_Return_ShoppingCart2_When_Select_Option_2()
        {
            //Arrange
            var shoppingCartNo = 2;
            var expectedResult = MockedData.MockedData.SetUpShoppingCart2();

            // Act
            var result = await _sut.GetShoppingCartAsync(shoppingCartNo);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
            result.Products.Select(c => c.Name).Should().Equal(expectedResult.Products.Select(c => c.Name));
            result.Products.Select(c => c.Price).Should().Equal(expectedResult.Products.Select(c => c.Price));
            result.Products.Select(c => c.Quantity).Should().Equal(expectedResult.Products.Select(c => c.Quantity));
            result.Products.Select(c => c.IsImported).Should().Equal(expectedResult.Products.Select(c => c.IsImported));
            result.Products.Select(c => c.ProductType).Should().Equal(expectedResult.Products.Select(c => c.ProductType));
        }

        [Fact]
        public async Task GetShoppingCartAsync_Should_Return_ShoppingCart2_When_Select_Option_3()
        {
            //Arrange
            var shoppingCartNo = 3;
            var expectedResult = MockedData.MockedData.SetUpShoppingCart3();

            // Act
            var result = await _sut.GetShoppingCartAsync(shoppingCartNo);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
            result.Products.Select(c => c.Name).Should().Equal(expectedResult.Products.Select(c => c.Name));
            result.Products.Select(c => c.Price).Should().Equal(expectedResult.Products.Select(c => c.Price));
            result.Products.Select(c => c.Quantity).Should().Equal(expectedResult.Products.Select(c => c.Quantity));
            result.Products.Select(c => c.IsImported).Should().Equal(expectedResult.Products.Select(c => c.IsImported));
            result.Products.Select(c => c.ProductType).Should().Equal(expectedResult.Products.Select(c => c.ProductType));
        }

        [Fact]
        public async Task GetShoppingCartAsync_Should_Return_An_Empty_Cart_When_Default()
        {
            //Arrange
            var shoppingCartNo = 4;

            // Act
            var result = await _sut.GetShoppingCartAsync(shoppingCartNo);

            //Assert
            result.Should().NotBeNull();
            result.Products.Count.Should().Be(0);
        }

        [Fact]
        public void CalculateTaxes_Should_Calculate_Taxes_And_Total()
        {
            //Arrange
            var expectedTax = 1.5m;
            var shoppingCart = MockedData.MockedData.SetUpShoppingCart1();
            var expectedTotalWithoutTaxes = shoppingCart.Products.Sum(p => p.Price);

            _calculateInvoiceMock.Setup(x => x.CalculateTaxes(shoppingCart)).Returns(expectedTax);

            // Act
            _sut.CalculateTotal(shoppingCart);

            //Assert
            shoppingCart.SalesTaxes.Should().Be(expectedTax);
            shoppingCart.Total.Should().Be(expectedTotalWithoutTaxes + expectedTax);
        }

        [Fact]
        public void CalculateTaxes_Should_Call_CalculateInvoice_CalculateTaxes_Once()
        {
            //Arrange
            var shoppingCart = new Fixture().Create<ShoppingCart>();

            // Act
            _sut.CalculateTotal(shoppingCart);

            //Assert
            _calculateInvoiceMock.Verify(m => m.CalculateTaxes(It.IsAny<ShoppingCart>()), Times.Once);
        }
    }
}
