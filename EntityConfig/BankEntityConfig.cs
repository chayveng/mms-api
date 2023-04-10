using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mms_api.Domain.Bank;

namespace mms_api.EntityConfig;

public class BankEntityConfig : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("ID");
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Initials).HasColumnName("Initials");
        builder.Property(e => e.ImageId).HasColumnName("Image_Id"); ;
        builder.Property(e => e.CREATE_DATETIME).HasColumnName("CREATED_DATETIME");
        builder.Property(e => e.UPDATE_DATETIME).HasColumnName("UPDATED_DATETIME");
    }
}

