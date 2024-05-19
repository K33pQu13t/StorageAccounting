using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "POSITION")
            .ToTable(t =>
            {
                t.HasComment("Позиция документа");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentId).HasColumnName("ID_DOCUMENT");

        builder.Property(x => x.ItemId).HasColumnName("ID_ITEM");

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Positions);
        builder
            .HasOne(x => x.Item)
            .WithMany(x => x.Positions);

        builder
            .HasMany(x => x.Moves)
            .WithOne(x => x.Position);
    }
}
