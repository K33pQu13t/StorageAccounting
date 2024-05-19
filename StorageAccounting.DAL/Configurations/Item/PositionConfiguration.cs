using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Configurations.Item;
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
