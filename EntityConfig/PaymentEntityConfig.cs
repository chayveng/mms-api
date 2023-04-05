using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mms_api.Domain.Payment;

namespace mms_api.EntityConfig;

public class PaymentEntityConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("ID");
        builder.Property(e => e.Code).HasColumnName("Code");
        builder.Property(e => e.Initials).HasColumnName("Initials");
        builder.Property(e => e.PaymentName).HasColumnName("Payment_Name");
        builder.Property(e => e.ImageId).HasColumnName("Image_Id");
        builder.Property(e => e.Status).HasColumnName("Status");
        builder.Property(e => e.CREATED_DATETIME).HasColumnName("CREATED_DATETIME");
        builder.Property(e => e.UPDATED_DATETIME).HasColumnName("UPDATED_DATETIME");
    }
}