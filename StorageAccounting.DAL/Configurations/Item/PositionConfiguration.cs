using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
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
