using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeStore.Shared.Models.Order;

namespace CoffeeStore.Server.Services.Order
{
    public interface IOrderService
    {
        Task<bool> CreateOrderItemAsync(OrderCreate model);
        Task<IEnumerable<OrderListItem>> GetAllOrderItemsAsync();
        Task<IEnumerable<OrderListItem>> GetAllOrderItemsByTransactionIdAsync(int transactionId);
        Task<OrderDetail> GetOrderItemByIdAsync(int itemId);
        Task<bool> UpdateOrderItemAsync(OrderEdit model);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
