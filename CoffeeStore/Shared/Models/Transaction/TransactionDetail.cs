using System;
namespace CoffeeStore.Shared.Models.Transaction
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
