using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PARTNER")
            .ToTable(t =>
            {
                t.HasComment("Партнёр");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PartnerTypeId).HasColumnName("Id_PartnerType");

        builder
            .HasOne(x => x.PartnerType)
            .WithMany(x => x.Partners)
            .HasForeignKey(x => x.PartnerTypeId);
    }
}
