using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Model;
using Repo.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repo.DTO;

namespace Repo.Api.Controllers
{
    
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [Authorize(Policy = "All")]
        [HttpGet]
        [Produces(typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategoryList()
        {
            IEnumerable<Category> category = await _categoryService.GetAllCategory();
            return Ok(category);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Produces(typeof(Category))]
        public IActionResult AddCategory(CategoryAddDTO addDTO)
        {
            return Ok(_categoryService.AddCategory(addDTO));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(User))]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO updateDTO)
        {
            return Ok(await _categoryService.UpdateCategory(updateDTO));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }

    }
}
