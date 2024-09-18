using ASP.NET.Dtos;

namespace Asp.Net.Core.Dtos
{
    public interface ICartServices
    {
        Task<IEnumerable<CartDto>> GetCarts();
        Task<CartDto> GetCart(int id);
        Task<CartDto> AddCart(CartDto cart);
        Task<CartDto> UpdateCart(CartDto cart);
        Task<CartDto> DeleteCart(int id);
    }
}