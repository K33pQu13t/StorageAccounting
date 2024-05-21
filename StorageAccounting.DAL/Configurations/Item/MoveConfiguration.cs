using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class MoveConfiguration : IEntityTypeConfiguration<Move>
{
    public void Configure(EntityTypeBuilder<Move> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "MOVE")
            .ToTable(t =>
            {
                t.HasComment("Движение позиции");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PositionId).HasColumnName("Id_Position");

        builder.Property(x => x.OperationId).HasColumnName("Id_Operation");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.Moves)
            .HasForeignKey(x => x.PositionId);

        builder
            .HasOne(x => x.Operation)
            .WithMany(x => x.Moves)
            .HasForeignKey(x => x.OperationId);
    }
}
