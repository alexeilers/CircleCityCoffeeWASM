using System;
namespace CoffeeStore.Shared.Models.Order
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
