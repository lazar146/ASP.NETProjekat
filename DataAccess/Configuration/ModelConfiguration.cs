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
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.brandId).IsRequired().HasMaxLength(100);
            builder.Property(m => m.RamMemory).IsRequired().HasMaxLength(100);
            builder.Property(m => m.StorageMemory).IsRequired().HasMaxLength(100);
            builder.Property(m => m.CameraMegapixels).IsRequired().HasMaxLength(100);

            builder.HasOne(m => m.brandModel)
              .WithMany(b => b.Models)
              .HasForeignKey(m => m.brandId);

            builder.HasMany(m => m.imagesModel)
                   .WithOne(i => i.ModelImg)
                   .HasForeignKey(i => i.ModelId);
        }
    }
}
