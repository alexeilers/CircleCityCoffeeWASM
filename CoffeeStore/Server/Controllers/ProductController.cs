using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Services.Product;
using CoffeeStore.Shared.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/Product
        [HttpGet]
        public async Task<List<ProductListItem>> Index()
        {
            var products = await _productService.GetAllProductsAsync();

            return products.ToList();
        }


        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ProductDetail> Product(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }


        // GET: api/Product/category/5
        [HttpGet("category/{id}")]
        public async Task<List<ProductDetail>> ProductsByCategory(int id)
        {
            var products = await _productService.GetAllProductsByCategoryIdAsync(id);

            return products.ToList();
        }


        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> Create(ProductCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSuccess = await _productService.CreateProductAsync(model);

            if (wasSuccess)
            {
                return Ok();
            }

            else return UnprocessableEntity();
        }


        // PUT: api/Product/edit/5
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccess = await _productService.UpdateProductAsync(model);

            if (wasSuccess) return Ok();

            return BadRequest();
        }


        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productEntity = await _productService.GetProductByIdAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            bool wasSuccess = await _productService.DeleteProductAsync(id);

            if (!wasSuccess) return BadRequest();

            return Ok();
        }
    }
}
