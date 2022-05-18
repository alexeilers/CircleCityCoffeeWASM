using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Shared.Models.Order
{
    public class OrderEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int QuantityOrdered { get; set; }
    }
}
