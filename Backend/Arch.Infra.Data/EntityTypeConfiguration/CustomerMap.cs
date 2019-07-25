using Arch.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Infra.Data.EntityTypeConfiguration
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(s => s.Name, cb => {
                cb.Property(c => c.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(60);
                cb.Property(c => c.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(80);
            });

            // builder.OwnsOne(s => s.Email, cb =>
            // {
            //     cb.Property(e => e.Email)
            //         .HasColumnName("Email")
            //         .IsRequired()
            //         .HasMaxLength(150);
            // });

            builder.OwnsOne(s => s.Address, cb =>
            {
                cb.Property(c => c.Number)
                    .HasColumnName("Number")
                    .HasMaxLength(20);
                cb.Property(c => c.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(120);
                cb.Property(c => c.ZipCode)
                    .HasColumnName("ZipCode")
                    .HasMaxLength(20);
                cb.Property(c => c.City)
                    .HasColumnName("City")
                    .HasMaxLength(80);
            });
                
        }
    }
}