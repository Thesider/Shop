using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Models;
using ASP.NET.Services.Interfaces;
using ASP.NET.Data;
using ASP.NET.Dtos;

namespace ASP.NET.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtos()
        {
            return await _context.Products
                .Select(p => MapToDto(p))
                .ToListAsync();
        }

        public async Task<ProductDto> GetProductDto(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<ProductDto> AddProductDto(ProductDto productDto)
        {
            var product = MapToEntity(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return MapToDto(product);
        }

        public async Task<ProductDto> UpdateProductDto(ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(productDto.Id);
            if (product == null) return null;

            MapToEntity(productDto, product);
            await _context.SaveChangesAsync();
            return MapToDto(product);
        }

        public async Task<ProductDto> DeleteProductDto(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return MapToDto(product);
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        private static Product MapToEntity(ProductDto dto, Product product = null)
        {
            product ??= new Product();
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            return product;
        }
    }
}