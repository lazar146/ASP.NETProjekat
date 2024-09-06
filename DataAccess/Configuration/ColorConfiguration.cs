using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();

            builder.HasMany(c => c.ModelColors)
               .WithOne(mc => mc.Colors)
               .HasForeignKey(mc => mc.ColorId);
        }
    }

}
