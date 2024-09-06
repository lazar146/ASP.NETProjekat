using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ProductCartConfiguration : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> builder)
        {
            builder.ToTable("ProductCarts");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Quanity).IsRequired().HasMaxLength(100);
            builder.Property(pc => pc.ModelColorId).IsRequired();
            builder.Property(pc => pc.CartId).IsRequired();
           

            builder.HasIndex(pc => pc.CartId);

            builder.HasOne(pc => pc.ModelColorsPC)
               .WithMany(mc => mc.ProductCartModelColor)
               .HasForeignKey(pc => pc.ModelColorId);

            builder.HasOne(pc => pc.Carts)
                   .WithMany(c => c.ProductCart)
                   .HasForeignKey(pc => pc.CartId);
        }
    }
}
