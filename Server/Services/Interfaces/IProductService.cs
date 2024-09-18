using ASP.NET.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductDtos();
        Task<ProductDto> GetProductDto(int id);
        Task<ProductDto> AddProductDto(ProductDto productDto);
        Task<ProductDto> UpdateProductDto(ProductDto productDto);
        Task<ProductDto> DeleteProductDto(int id);
    }
}