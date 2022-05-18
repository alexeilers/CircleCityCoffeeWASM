using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Services.Category;
using CoffeeStore.Shared.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //INDEX
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }


        //POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }


        //GET: api/Category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }


        //PUT: api/Category/edit/1
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CategoryEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _categoryService.UpdateCategoryAsync(model);

            if (wasSuccessful) return Ok();

            return BadRequest();
        }


        //DELETE: api/Category/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null) return NotFound();

            bool wasSuccessful = await _categoryService.DeleteCategoryAsync(id);

            if (!wasSuccessful) return BadRequest();

            return Ok();
        }
    }
}
