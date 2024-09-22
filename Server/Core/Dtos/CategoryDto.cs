namespace ASP.NET.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}

