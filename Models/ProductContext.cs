
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
           
            Database.EnsureCreated();
        }
    }
}
