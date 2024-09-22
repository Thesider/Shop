using ASP.NET.Dtos;
using ASP.NET.Data.Interfaces;
using ASP.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NET.Services.Interfaces;

namespace ASP.NET.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrderDtos()
        {
            var orders = await _orderRepository.GetOrders();
            return orders.Select(o => MapToDto(o)).ToList();
        }

        public async Task<OrderDto> GetOrderDto(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            return order != null ? MapToDto(order) : null;
        }

        public async Task<OrderDto> AddOrderDto(OrderDto orderDto)
        {
            var order = MapToEntity(orderDto);
            var addedOrder = await _orderRepository.AddOrder(order);
            return MapToDto(addedOrder);
        }

        public async Task<OrderDto> UpdateOrderDto(OrderDto orderDto)
        {
            var order = MapToEntity(orderDto);
            var updatedOrder = await _orderRepository.UpdateOrder(order);
            return MapToDto(updatedOrder);
        }

        public async Task<OrderDto> DeleteOrderDto(int id)
        {
            var order = await _orderRepository.DeleteOrder(id);
            return order != null ? MapToDto(order) : null;
        }

        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    OrderId = oi.OrderId
                }).ToList()
            };
        }

        private static Order MapToEntity(OrderDto orderDto)
        {
            return new Order
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
                OrderDate = orderDto.OrderDate,
                OrderItems = orderDto.OrderItems.Select(oi => new OrderItem
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    OrderId = oi.OrderId
                }).ToList()
            };
        }
    }
}