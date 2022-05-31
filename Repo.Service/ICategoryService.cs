using Repo.Model;
using Repo.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo.DTO;

namespace Repo.Service
{
    public interface ICategoryService
    {

        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task<bool> AddCategory(CategoryAddDTO addDTO);
        Task<bool> UpdateCategory(CategoryUpdateDTO updateDTO);
        Task<bool> DeleteCategory(int id);

    }

    public class CategoryService : ICategoryService
    {
       private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(CategoryAddDTO addDTO)
        {
          
            
            try
            {
                var Category = new Category();
                Category.CategoryName = addDTO.CategoryName;
                await _categoryRepository.Add(Category);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<bool> UpdateCategory(CategoryUpdateDTO updateDTO)
        {
            try
            {
                var Category = new Category();
                Category.CategoryId = updateDTO.CategoryId;
                Category.CategoryName= updateDTO.CategoryName.Trim();

                Category _category = await GetCategoryById(Category.CategoryId);
                if (_category != null)
                {
                    _category.CategoryName = Category.CategoryName;
                   
                    await _categoryRepository.Update(_category);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
