using Arch.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Infra.Data.EntityTypeConfiguration
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(s => 
            s.Price, cb => {
                cb.Property(_ => _.Normal);
                cb.Property(_ => _.Promotional);
                cb.Property(_ => _.PromotionInit);
                cb.Property(_ => _.PromotionLimit);
            });
        }
    }
}