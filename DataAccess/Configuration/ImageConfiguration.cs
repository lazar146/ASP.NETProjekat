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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ImageName).IsRequired();
            builder.Property(i => i.ImageUrl).IsRequired();
            builder.Property(i => i.ModelId).IsRequired();


            builder.HasOne(i => i.ModelImg)
              .WithMany(m => m.imagesModel)
              .HasForeignKey(i => i.ModelId);
        }
    }

}
