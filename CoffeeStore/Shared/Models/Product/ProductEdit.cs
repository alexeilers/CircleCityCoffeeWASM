using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Shared.Models.Product
{
    public class ProductEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}