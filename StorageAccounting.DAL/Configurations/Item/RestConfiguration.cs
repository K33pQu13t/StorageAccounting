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
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PlaceId).HasColumnName("Id_Place");

        builder.Property(x => x.ItemId).HasColumnName("Id_Item");

        builder
            .HasOne(x => x.Place)
            .WithMany(x => x.Rests)
            .HasForeignKey(x => x.PlaceId);

        builder
            .HasOne(x => x.Item)
            .WithMany(x => x.Rests)
            .HasForeignKey(x => x.ItemId);
    }
}
