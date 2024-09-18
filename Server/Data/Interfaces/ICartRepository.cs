using ASP.NET.Models;


namespace ASP.NET.Data.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCarts();
        Task<Cart> GetCart(int id);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int id);
    }
}