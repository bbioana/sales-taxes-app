using SalesTaxes.Data.Interfaces;

namespace SalesTaxes.Data.Services
{
    public class CalculateInvoiceService : ICalculateInvoice
    {
        private readonly decimal basicTax = 0.1m;
        private readonly decimal importedTax = 0.05m;

        public decimal CalculateTaxes(ShoppingCart shoppingCart)
        {
            decimal totalTaxes = 0.00m;
            foreach (var product in shoppingCart.Products)
            {
                var productTaxes = 0.00m;
                //Basic tax is applicable at a rate of 10% on all goods, except books, food, and medical products.
                if (product.ProductType == ProductType.Others)
                {
                    var basicTaxValue = Math.Ceiling(product.Price * basicTax * 20) / 20;
                    productTaxes += basicTaxValue;
                    totalTaxes += basicTaxValue;
                }

                //Import duty is an additional tax applicable on all imported goods at a rate of 5%, with no exceptions.
                if (product.IsImported)
                {
                    var importedTaxValue = Math.Ceiling(product.Price * importedTax * 20) / 20;
                    productTaxes += importedTaxValue;
                    totalTaxes += importedTaxValue;
                }

                product.PriceWithTaxes = product.Price + productTaxes;
            }

            return totalTaxes;
        }
    }
}
