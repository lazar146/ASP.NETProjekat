using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId).IsRequired();


            builder.HasOne(c => c.userCart)
              .WithMany(u => u.UserCart)
              .HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.ProductCart)
                   .WithOne(pc => pc.Carts)
                   .HasForeignKey(pc => pc.CartId);
        }
    }

}
