using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class PartnerTypeConfiguration : IEntityTypeConfiguration<PartnerType>
{
    public void Configure(EntityTypeBuilder<PartnerType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PARTNERTYPE")
            .ToTable(t =>
            {
                t.HasComment("Тип партнёра");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasIdentityOptions(startValue: 100)
            .UseIdentityAlwaysColumn();

        builder
            .HasMany(x => x.Partners)
            .WithOne(x => x.PartnerType)
            .HasForeignKey(x => x.PartnerTypeId);
    }
}
