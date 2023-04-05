using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mms_api.Domain.Business;

namespace mms_api.EntityConfig
{
    class BusinessEntityConfig : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("ID");
            builder.Property(b => b.BusinessId).HasColumnName("BUSINESS_ID");
            builder.Property(b => b.TypeName).HasColumnName("Type_Name");
            builder.Property(b => b.Status).HasColumnName("Status");
            builder.Property(b => b.CREATE_DATETIME).HasColumnName("CREATED_DATETIME");
            builder.Property(b => b.UPDATE_DATETIME).HasColumnName("UPDATED_DATETIME");
        }
    }
}