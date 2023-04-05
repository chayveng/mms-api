using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mms_api.Domain.Image;

namespace mms_api.EntityConfig;

public class ImageEntityConfig : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("ID");
        builder.Property(e => e.ImageId).HasColumnName("IMAGE_ID");
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Type).HasColumnName("Type");
        builder.Property(e => e.File).HasColumnName("File");
        builder.Property(e => e.CREATED_DATETIME).HasColumnName("CREATED_DATETIME");
        builder.Property(e => e.UPDATED_DATETIME).HasColumnName("UPDATED_DATETIME"); 
    }
    
}