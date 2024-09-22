using ASP.NET.Dtos;

namespace ASP.NET.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<CategoryDto> AddCategory(CategoryDto categoryDto);
        Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);
        Task<CategoryDto> DeleteCategory(int id);
    }
}