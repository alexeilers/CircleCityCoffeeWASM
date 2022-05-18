using System;
namespace CoffeeStore.Shared.Models.Transaction
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
