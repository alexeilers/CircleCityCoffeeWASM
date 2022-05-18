using System;
namespace CoffeeStore.Shared.Models.Order
{
    public class OrderListItem
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
