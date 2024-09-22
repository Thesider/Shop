using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Models;
using ASP.NET.Services.Interfaces;
using ASP.NET.Data;
using ASP.NET.Dtos;
using ASP.NET.Data.Interfaces;

namespace ASP.NET.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<CartDto>> GetCarts()
        {
            var carts = await _cartRepository.GetCarts();
            return carts.Select(c => MapToDto(c)).ToList();
        }

        public async Task<CartDto> GetCart(int id)
        {
            var cart = await _cartRepository.GetCart(id);
            return cart != null ? MapToDto(cart) : null;
        }

        public async Task<CartDto> AddCart(CartDto cartDto)
        {
            var cart = MapToEntity(cartDto);
            var addedCart = await _cartRepository.AddCart(cart);
            return MapToDto(addedCart);
        }

        public async Task<CartDto> UpdateCart(CartDto cartDto)
        {
            var cart = MapToEntity(cartDto);
            var updatedCart = await _cartRepository.UpdateCart(cart);
            return MapToDto(updatedCart);
        }

        public async Task<CartDto> DeleteCart(int id)
        {
            var cart = await _cartRepository.DeleteCart(id);
            return cart != null ? MapToDto(cart) : null;
        }

        private static CartDto MapToDto(Cart cart)
        {
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Quantity = cart.Quantity,
                TotalPrice = cart.TotalPrice,
                CartItems = cart.CartItems.Select(ci => new CartItemDto
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }
        private static Cart MapToEntity(CartDto dto, Cart cart = null)
        {
            if (cart == null)
            {
                cart = new Cart();
            }

            cart.UserId = dto.UserId;
            cart.Quantity = dto.Quantity;
            cart.TotalPrice = dto.TotalPrice;
            cart.CartItems = dto.CartItems.Select(ci => new CartItem
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,

            }).ToList();

            return cart;
        }
    }
}

