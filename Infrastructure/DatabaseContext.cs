using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Bank;
using mms_api.Domain.Business;
using mms_api.Domain.Image;
using mms_api.Domain.Payment;
using mms_api.EntityConfig;

namespace mms_api.Infrastucture
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessEntityConfig());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfig());
            modelBuilder.ApplyConfiguration(new BankEntityConfig());
            modelBuilder.ApplyConfiguration(new ImageEntityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}