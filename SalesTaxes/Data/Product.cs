namespace SalesTaxes.Data
{
    public class Product
    {
        public string? Name { get; set; }

        public decimal Price { get; set; } 

        public int Quantity { get; set; }

        public ProductType  ProductType { get; set; }

        public bool IsImported { get; set; }

        public decimal PriceWithTaxes { get; set; }

        public Product(int quantity, string name, decimal price, ProductType productType, bool isImported)
        {
            this.Quantity = quantity;
            this.Name = name;
            this.Price = price;
            this.ProductType = productType;
            this.IsImported = isImported;
                

        }
    }
}
