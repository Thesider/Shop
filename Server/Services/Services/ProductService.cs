using ASP.NET.Dtos;
using ASP.NET.Data.Interfaces;
using ASP.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NET.Services.Interfaces;

namespace ASP.NET.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtos()
        {
            var products = await _productRepository.GetProducts();
            return products.Select(p => MapToDto(p)).ToList();
        }

        public async Task<ProductDto> GetProductDto(int id)
        {
            var product = await _productRepository.GetProduct(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<ProductDto> AddProductDto(ProductDto productDto)
        {
            var product = MapToEntity(productDto);
            var addedProduct = await _productRepository.AddProduct(product);
            return MapToDto(addedProduct);
        }

        public async Task<ProductDto> UpdateProductDto(ProductDto productDto)
        {
            var product = MapToEntity(productDto);
            var updatedProduct = await _productRepository.UpdateProduct(product);
            return MapToDto(updatedProduct);
        }

        public async Task<ProductDto> DeleteProductDto(int id)
        {
            var product = await _productRepository.DeleteProduct(id);
            return product != null ? MapToDto(product) : null;
        }

     private static ProductDto MapToDto(Product product)
{
    return new ProductDto
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        ImageUrl = product.ImageUrl,
        CategoryId = product.CategoryId,
        Category = new CategoryDto
        {
            Id = product.Category.CategoryId,
            CategoryName = product.Category.CategoryName,
            Description = product.Category.Description
        }
    };
}
        private static Product MapToEntity(ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.CategoryId,
            
            };
        }
    }
}

        