using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Data;
using CoffeeStore.Server.Models;
using CoffeeStore.Shared.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.Server.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }



        //CREATE
        public async Task<bool> CreateProductAsync(ProductCreate model)
        {
            var product = new ProductEntity
            {
                Name = model.Name,
                QuantityInStock = model.QuantityInStock,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            _context.Products.Add(product);
            var numberofChanges = await _context.SaveChangesAsync();

            return numberofChanges == 1;
        }



        //GET ALL
        public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
        {
            var product = _context.Products.Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Name,
                QuantityInStock = p.QuantityInStock,
                Description = p.Description,
                Price = p.Price
            });

            return await product.ToListAsync();
        }



        //GET BY ID
        public async Task<ProductDetail> GetProductByIdAsync(int productId)
        {
            var productEntity = await _context.Products
                .Include(nameof(Category))
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (productEntity == null) return null;

            var product = new ProductDetail
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                QuantityInStock = productEntity.QuantityInStock,
                Description = productEntity.Description,
                Price = productEntity.Price,
                CategoryId = productEntity.Category.Id,
                CategoryName = productEntity.Category.Name
            };

            return product;
        }



        //GET BY CATEGORY ID
        public async Task<IEnumerable<ProductDetail>> GetAllProductsByCategoryIdAsync(int categoryId)
        {
            var productQuery = _context.Products.Where(p => p.CategoryId == categoryId).Select(p => new ProductDetail
            {
                Id = p.Id,
                Name = p.Name,
                QuantityInStock = p.QuantityInStock,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.Category.Id,
                CategoryName = p.Category.Name
            });

            return await productQuery.ToListAsync();
        }



        //UPDATE
        public async Task<bool> UpdateProductAsync(ProductEdit model)
        {
            if (model == null) return false;

            var productEntity = await _context.Products.FindAsync(model.Id);

            productEntity.Name = model.Name;
            productEntity.QuantityInStock = model.QuantityInStock;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            productEntity.CategoryId = model.CategoryId;

            return await _context.SaveChangesAsync() == 1;
        }



        //DELETE
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
