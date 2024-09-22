using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET.Models;
[Table("Categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public List<Product> Products { get; set; } = new List<Product>();
    
}