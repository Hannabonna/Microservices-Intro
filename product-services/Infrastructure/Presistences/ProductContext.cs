using product_services.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace product_services.Infrastructure.Presistences
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> op) : base (op) {}
        
        public DbSet<ProductEn> Products { get; set; }
    }
}