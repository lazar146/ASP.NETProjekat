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
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PriceValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ModelColorId).IsRequired();
            

            builder.HasIndex(p => p.ModelColorId);

            builder.HasOne(p => p.ModelColorPrice)
                 .WithMany(mc => mc.PriceModelColor)
                 .HasForeignKey(p => p.ModelColorId);
        }
    }

}
