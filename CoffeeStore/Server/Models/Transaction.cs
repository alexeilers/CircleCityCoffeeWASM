using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Server.Models
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public double OrderTotal { get; set; }

        [Required]
        public DateTime DateofTransaction { get; set; }


    }
}
