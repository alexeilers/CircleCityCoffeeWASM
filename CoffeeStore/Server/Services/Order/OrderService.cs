using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Data;
using CoffeeStore.Server.Models;
using CoffeeStore.Shared.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.Server.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }


        //CREATE
        public async Task<bool> CreateOrderItemAsync(OrderCreate model)
        {
            var order = new OrderEntity
            {
                TransactionId = model.TransactionId,
                ProductId = model.ProductId,
                Quantity = model.QuantityOrdered
            };

            _context.Orders.Add(order);
            var numberofChanges = await _context.SaveChangesAsync();

            return numberofChanges == 1;
        }



        //GET ALL
        public async Task<IEnumerable<OrderListItem>> GetAllOrderItemsAsync()
        {
            var order = _context.Orders
                .Select(o => new OrderListItem
            {
                TransactionId = o.TransactionId,
                ProductId = o.ProductId,
                QuantityOrdered = o.Quantity
            });

            return await order.ToListAsync();
        }



        //GET BY TRANSACTION ID
        public async Task<IEnumerable<OrderListItem>> GetAllOrderItemsByTransactionIdAsync(int transactionId)
        {
            var order = _context.Orders
                .Where(o => o.TransactionId == transactionId)
                .Select(o => new OrderListItem
                {
                    TransactionId = o.TransactionId,
                    ProductId = o.ProductId,
                    QuantityOrdered = o.Quantity
                });

            return await order.ToListAsync();
        }



        //GET BY ID
        public async Task<OrderDetail> GetOrderItemByIdAsync(int itemId)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(i => i.Id == itemId);

            if (order == null) return null;

            var detail = new OrderDetail
            {
                Id = order.Id,
                TransactionId = order.TransactionId,
                ProductId = order.ProductId,
                QuantityOrdered = order.Quantity
            };

            return detail;
        }



        //UPDATE
        public async Task<bool> UpdateOrderItemAsync(OrderEdit model)
        {
            if (model == null) return false;

            var order = await _context.Orders.FindAsync(model.Id);

            order.TransactionId = model.TransactionId;
            order.ProductId = model.ProductId;
            order.Quantity = model.QuantityOrdered;

            return await _context.SaveChangesAsync() == 1;
        }



        //DELTE
        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
