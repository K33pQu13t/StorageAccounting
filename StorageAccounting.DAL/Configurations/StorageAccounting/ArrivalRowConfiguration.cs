using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;

internal class ArrivalRowConfiguration : IEntityTypeConfiguration<ArrivalRow>
{
    public void Configure(EntityTypeBuilder<ArrivalRow> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "ARRIVALROW")
            .ToTable(t =>
            {
                t.HasComment("Позиция документа поступления извне");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PositionId).HasColumnName("ID_POSITION");

        builder.Property(x => x.MarkId).HasColumnName("ID_MARK");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.ArrivalRows);

        builder
            .HasOne(x => x.Mark)
            .WithMany(x => x.ArrivalRows);
    }
}
