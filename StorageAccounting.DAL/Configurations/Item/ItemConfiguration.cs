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
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.ProductTypeId).HasColumnName("Id_ProductType");

        builder.Property(x => x.UnitId).HasColumnName("Id_Unit");

        builder.Property(x => x.PlaceId).HasColumnName("Id_Place");

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ProductTypeId);

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.UnitId);

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.PlaceId);
    }
}
