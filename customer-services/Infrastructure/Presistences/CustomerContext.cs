using customer_services.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace customer_services.Infrastructure.Presistences
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> op) : base (op) {}
        
        public DbSet<CustomerEn> Customers { get; set; }
        public DbSet<PaymentEn> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model
                 .Entity<PaymentEn>()
                 .HasOne(i => i.customer)
                 .WithMany()
                 .HasForeignKey(i => i.Customer_Id);
        }
    }
}