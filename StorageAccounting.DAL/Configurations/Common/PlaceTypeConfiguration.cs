using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class PlaceTypeConfiguration : IEntityTypeConfiguration<PlaceType>
{
    public void Configure(EntityTypeBuilder<PlaceType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "PLACETYPE")
            .ToTable(t =>
            {
                t.HasComment("Тип склада");
            });

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Places)
            .WithOne(x => x.PlaceType);
    }
}
