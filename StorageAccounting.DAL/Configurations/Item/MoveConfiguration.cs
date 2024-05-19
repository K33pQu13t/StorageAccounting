using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Configurations.Item;
internal class MoveConfiguration : IEntityTypeConfiguration<Move>
{
    public void Configure(EntityTypeBuilder<Move> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.Moves);

        builder
            .HasOne(x => x.Operation)
            .WithMany(x => x.Moves);
    }
}
