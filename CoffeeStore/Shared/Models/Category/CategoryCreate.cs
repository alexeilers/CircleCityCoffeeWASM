using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Shared.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
