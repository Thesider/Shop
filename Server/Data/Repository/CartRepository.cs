using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Data.Interfaces;
using ASP.NET.Models;

namespace ASP.NET.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private List<Cart> _carts;

        public CartRepository()
        {
            _carts = new List<Cart>();
        }

        public async Task<IEnumerable<Cart>> GetCarts()
        {
            return await Task.FromResult(_carts);
        }

        public async Task<Cart> GetCart(int id)
        {
            return await Task.FromResult(_carts.FirstOrDefault(c => c.Id == id));
        }

        public async Task<Cart> AddCart(Cart cart)
        {
            if (_carts.Count > 0)
            {
                cart.Id = _carts.Max(c => c.Id) + 1;
            }
            else
            {
                cart.Id = 1;
            }
            _carts.Add(cart);
            return await Task.FromResult(cart);
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var existingCart = _carts.FirstOrDefault(c => c.Id == cart.Id);
            if (existingCart != null)
            {
                existingCart.ProductId = cart.ProductId;
                existingCart.Quantity = cart.Quantity;
                existingCart.UserId = cart.UserId;
            }
            return await Task.FromResult(existingCart);
        }

        public async Task<Cart> DeleteCart(int id)
        {
            var cart = _carts.FirstOrDefault(c => c.Id == id);
            if (cart != null)
            {
                _carts.Remove(cart);
            }
            return await Task.FromResult(cart);
        }
    }
}