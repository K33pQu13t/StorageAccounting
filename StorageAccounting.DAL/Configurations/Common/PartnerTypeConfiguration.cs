using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
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
