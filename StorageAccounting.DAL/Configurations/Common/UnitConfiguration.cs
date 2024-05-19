using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;

internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "UNIT")
            .ToTable(t =>
            {
                t.HasComment("Единица измерения");
            });

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Unit);
    }
}
