using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Services.Order;
using CoffeeStore.Shared.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderedItemService;

        public OrderController(IOrderService orderedItemService)
        {
            _orderedItemService = orderedItemService;
        }


        //POST: api/OrderedItem
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSuccess = await _orderedItemService.CreateOrderItemAsync(model);

            if (wasSuccess) return Ok();

            else return UnprocessableEntity();
        }


        //GET: api/OrderedItem
        [HttpGet]
        public async Task<List<OrderListItem>> Index()
        {
            var items = await _orderedItemService.GetAllOrderItemsAsync();

            return items.ToList();
        }


        //GET: api/OrderedItem/1
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderedItem(int id)
        {
            var orderedItem = await _orderedItemService.GetOrderItemByIdAsync(id);

            if (orderedItem == null) return NotFound();

            return Ok(orderedItem);
        }


        // GET: api/OrderedItem/getAll/1
        [HttpGet("getAll/{transactionId}")]
        public async Task<List<OrderListItem>> OrderedItems(int transactionId)
        {
            var items = await _orderedItemService.GetAllOrderItemsByTransactionIdAsync(transactionId);

            return items.ToList();
        }


        //PUT: api/OrderedItem/1
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, OrderEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccess = await _orderedItemService.UpdateOrderItemAsync(model);

            if (!wasSuccess) return BadRequest();

            return Ok();
        }


        //DELETE: api/OrderedItem/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderedItem = await _orderedItemService.GetOrderItemByIdAsync(id);

            if (orderedItem == null) return NotFound();

            bool wasSuccessful = await _orderedItemService.DeleteOrderItemAsync(id);

            if (!wasSuccessful) return BadRequest();

            return Ok();
        }
    }
}
