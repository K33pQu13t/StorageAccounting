using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StorageAccounting.Domain.Configurations.Item;

internal class ItemConfiguration : IEntityTypeConfiguration<Models.Item.Item>
{
    public void Configure(EntityTypeBuilder<Models.Item.Item> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "ITEM")
            .ToTable(t =>
            {
                t.HasComment("Учётная единица");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductTypeId).HasColumnName("ID_PRODUCTTYPE");

        builder.Property(x => x.UnitId).HasColumnName("ID_UNIT");

        builder.Property(x => x.PlaceId).HasColumnName("ID_PLACE");

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.Items);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.Items);

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Items);
    }
}
