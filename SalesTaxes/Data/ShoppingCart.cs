namespace SalesTaxes.Data
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }

        public decimal Total { get; set; }

        public decimal SalesTaxes { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
            Total = 0;
            SalesTaxes = 0;
        }
    }
}
