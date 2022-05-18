using System;
namespace CoffeeStore.Shared.Models.Product
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
