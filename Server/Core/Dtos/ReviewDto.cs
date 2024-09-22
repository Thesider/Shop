using ASP.NET.Models;

namespace ASP.NET.Dtos
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product  Product { get; set; }
    }
}