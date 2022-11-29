using SalesTaxes.Data;

namespace SalesTaxes.MockedData
{
    public static class MockedData
    {
        public static ShoppingCart SetUpShoppingCart1()
        {
            return new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(1, "Book", 12.49m, ProductType.Books, false),
                    new Product(1, "Music CD", 14.99m, ProductType.Others, false),
                    new Product(1, "Chocolate bar", 0.85m, ProductType.Food, false)
                }
            };

        }

        public static ShoppingCart SetUpShoppingCart2()
        {
            return new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(1, "Imported box of chocolates", 10.00m, ProductType.Food, true),
                    new Product(1, "Imported bottle of perfume", 47.50m, ProductType.Others, true)
                }
            };

        }

        public static ShoppingCart SetUpShoppingCart3()
        {
            return new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product(1, "Imported bottle of perfume", 27.99m, ProductType.Others, true),
                    new Product(1, "Bottle of perfume", 18.99m, ProductType.Others, false),
                    new Product(1, "Packet of paracetamol", 9.75m, ProductType.MedicalProduct, false),
                    new Product(1, "Box of imported chocolates", 11.25m, ProductType.Food, true),
                }
            };

        }

    }
}

