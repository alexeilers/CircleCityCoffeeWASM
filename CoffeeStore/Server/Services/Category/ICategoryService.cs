using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeStore.Shared.Models.Category;

namespace CoffeeStore.Server.Services.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
