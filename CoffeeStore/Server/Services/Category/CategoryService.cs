using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Data;
using CoffeeStore.Server.Models;
using CoffeeStore.Shared.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.Server.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        //CREATE 
        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            if (model == null) return false;

            var categoryEntity = new CategoryEntity
            {
                Name = model.Name
            };

            _context.Categories.Add(categoryEntity);
            return await _context.SaveChangesAsync() == 1;
        }



        //GET ALL
        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var category = _context.Categories
                .Select(entity => new CategoryListItem
            {
                Id = entity.Id,
                Name = entity.Name
            });

            return await category.ToListAsync();
        }



        //GET BY ID
        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null) return null;

            var categoryDetail = new CategoryDetail
            {
                Id = category.Id,
                Name = category.Name,
            };

            return categoryDetail;
        }



        //UPDATE
        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            if (model == null) return false;

            var category = await _context.Categories.FindAsync(model.Id);

            category.Name = model.Name;

            return await _context.SaveChangesAsync() == 1;
        }



        //DELETE
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            _context.Categories.Remove(category);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
