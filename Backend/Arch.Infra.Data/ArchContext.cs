using Arch.Domain;
using Arch.Domain.Account;
using Arch.Infra.Data.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Arch.Infra.Data
{
    public class ArchContext: DbContext
    {
        public ArchContext(DbContextOptions<ArchContext> options)
            :base(options) {}

        public DbSet<Customer> Customers {get;set;}
        public DbSet<User> Users {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
    }
}