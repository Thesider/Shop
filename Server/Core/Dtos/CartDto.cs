using ASP.NET.Dtos;
    
namespace ASP.NET.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

    
        public List<CartItemDto> CartItems { get; set; }
    }
}
