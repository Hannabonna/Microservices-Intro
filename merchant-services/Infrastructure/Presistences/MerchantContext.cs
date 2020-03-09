using Microsoft.EntityFrameworkCore;
using merchant_services.Domain.Entities;

namespace merchant_services.Infrastructure.Presistences
{
    public class MerchantContext : DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> op) : base (op) {}
        
        public DbSet<MerchantEn> Merchants { get; set; }
    }
}