using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class RestConfiguration : IEntityTypeConfiguration<Rest>
{
    public void Configure(EntityTypeBuilder<Rest> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "REST")
            .ToTable(t =>
            {
                t.HasComment("Остаток");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PlaceId).HasColumnName("ID_PLACE");

        builder.Property(x => x.ItemId).HasColumnName("ID_ITEM");

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Rests);

        builder
            .HasOne(x => x.Item)
            .WithMany(x => x.Rests);
    }
}
