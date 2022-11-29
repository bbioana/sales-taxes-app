using SalesTaxes.Data.Interfaces;

namespace SalesTaxes.Data.Services
{
    public class ShoppingCartService
    {
        private readonly ICalculateInvoice _calculateInvoice;

        public ShoppingCartService(ICalculateInvoice calculateInvoice)
        {
            _calculateInvoice = calculateInvoice;
        }

        public Task<ShoppingCart> GetShoppingCartAsync(int shoppingCartNo)
        {
            switch (shoppingCartNo)
            {
                case 1:
                    return Task.FromResult(MockedData.MockedData.SetUpShoppingCart1());
                case 2:
                    return Task.FromResult(MockedData.MockedData.SetUpShoppingCart2());
                case 3:
                    return Task.FromResult(MockedData.MockedData.SetUpShoppingCart3());
                default: return Task.FromResult(new ShoppingCart());
            }
            
        }

        public void CalculateTotal(ShoppingCart shoppingCart)
        {
            var totalSalesTaxes = _calculateInvoice.CalculateTaxes(shoppingCart);
            shoppingCart.SalesTaxes = totalSalesTaxes;

            var totalWithoutTaxes = shoppingCart.Products.Sum(p => p.Price);
            shoppingCart.Total = totalWithoutTaxes + totalSalesTaxes;
        }
    }
}
