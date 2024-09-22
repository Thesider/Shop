using ASP.NET.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrderDtos();
        Task<OrderDto> GetOrderDto(int id);
        Task<OrderDto> AddOrderDto(OrderDto orderDto);
        Task<OrderDto> UpdateOrderDto(OrderDto orderDto);
        Task<OrderDto> DeleteOrderDto(int id);
    }
}