using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Shared.Models.Order
{
    public class OrderCreate
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int QuantityOrdered { get; set; }
    }
}
