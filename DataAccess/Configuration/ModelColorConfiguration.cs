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
    public class ModelColorConfiguration : IEntityTypeConfiguration<ModelColor>
    {
        public void Configure(EntityTypeBuilder<ModelColor> builder)
        {
            builder.ToTable("ModelColors");
            builder.HasKey(mc => mc.Id);
            builder.Property(mc => mc.ModelId).IsRequired();
            builder.Property(mc => mc.ColorId).IsRequired();
            

            builder.HasIndex(mc => mc.ModelId);

            builder.HasOne(mc => mc.Colors)
              .WithMany(c => c.ModelColors)
              .HasForeignKey(mc => mc.ColorId);

            builder.HasOne(mc => mc.Models)
                   .WithMany(m => m.colorsModel)
                   .HasForeignKey(mc => mc.ModelId);
        }
    }

}
