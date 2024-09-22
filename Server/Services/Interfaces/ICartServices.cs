using ASP.NET.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetCarts();
        Task<CartDto> GetCart(int id);
        Task<CartDto> AddCart(CartDto cart);
        Task<CartDto> UpdateCart(CartDto cart);
        Task<CartDto> DeleteCart(int id);
    }
}