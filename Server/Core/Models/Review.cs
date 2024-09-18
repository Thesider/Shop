using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}