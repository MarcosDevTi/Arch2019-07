using Arch.Domain;
using Arch.Domain.Account;
using Arch.Domain.ValueObjects;
using Arch.Infra.Data.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Arch.Infra.Data
{
    public class ArchContext: DbContext
    {
        public ArchContext(DbContextOptions<ArchContext> options)
            :base(options) {}
        public DbSet<User> Users {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Brand> Brands {get;set;}
        public DbSet<Distribuitor> Distribuitors {get;set;}
        

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}