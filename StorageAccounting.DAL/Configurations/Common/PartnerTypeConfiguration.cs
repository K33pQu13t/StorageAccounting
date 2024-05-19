using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class PartnerTypeConfiguration : IEntityTypeConfiguration<PartnerType>
{
    public void Configure(EntityTypeBuilder<PartnerType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Partners)
            .WithOne(x => x.PartnerType);
    }
}
