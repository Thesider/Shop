using ASP.NET.Dtos;
using ASP.NET.Data.Interfaces;
using ASP.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NET.Services.Interfaces;

namespace ASP.NET.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return categories.Select(c => MapToDto(c)).ToList();
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            return category != null ? MapToDto(category) : null;
        }

        public async Task<CategoryDto> AddCategory(CategoryDto categoryDto)
        {
            var category = MapToEntity(categoryDto);
            var addedCategory = await _categoryRepository.AddCategory(category);
            return MapToDto(addedCategory);
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            var category = MapToEntity(categoryDto);
            var updatedCategory = await _categoryRepository.UpdateCategory(category);
            return MapToDto(updatedCategory);
        }

        public async Task<CategoryDto> DeleteCategory(int id)
        {
            var category = await _categoryRepository.DeleteCategory(id);
            return category != null ? MapToDto(category) : null;
        }

        private static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        private static Category MapToEntity(CategoryDto dto, Category category = null)
        {
            if (category == null)
            {
                category = new Category();
            }

            category.CategoryName = dto.CategoryName;
            category.Description = dto.Description;

            return category;
        }
    }
}