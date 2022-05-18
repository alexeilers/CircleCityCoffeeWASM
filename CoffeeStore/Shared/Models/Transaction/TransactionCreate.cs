using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Shared.Models.Transaction
{
    public class TransactionCreate
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public double OrderTotal { get; set; }
    }
}
