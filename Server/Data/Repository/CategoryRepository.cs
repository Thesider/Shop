using ASP.NET.Data.Interfaces;
using ASP.NET.Models;

namespace ASP.NET.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<Category> GetCategory(int id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(c => c.CategoryId == id));
        }

        public async Task<Category> AddCategory(Category category)
        {
            if (_categories.Count > 0)
            {
                category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            _categories.Add(category);
            return await Task.FromResult(category);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
            }
            return await Task.FromResult(existingCategory);
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            return await Task.FromResult(category);
        }

        
    }
}