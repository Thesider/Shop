
using ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Data
{
    public class  DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
    }
}