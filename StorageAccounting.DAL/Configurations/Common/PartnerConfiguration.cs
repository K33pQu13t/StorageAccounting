using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.PartnerType)
            .WithMany(x => x.Partners);
    }
}
