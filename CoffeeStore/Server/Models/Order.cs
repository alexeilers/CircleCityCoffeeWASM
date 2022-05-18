using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Server.Models
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransactionId { get; set; }
        public virtual TransactionEntity Transaction { get; set; }

        public int ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }

        public int Quantity { get; set; }
    }
}
