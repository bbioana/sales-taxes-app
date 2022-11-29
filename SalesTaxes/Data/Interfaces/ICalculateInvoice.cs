namespace SalesTaxes.Data.Interfaces
{
    public interface ICalculateInvoice
    {
        decimal CalculateTaxes(ShoppingCart shoppingCart);
    }
}
