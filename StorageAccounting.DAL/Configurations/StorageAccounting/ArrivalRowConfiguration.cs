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
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PositionId).HasColumnName("Id_Position");

        builder.Property(x => x.MarkId).HasColumnName("Id_Mark");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.ArrivalRows)
            .HasForeignKey(x => x.PositionId);

        builder
            .HasOne(x => x.Mark)
            .WithMany(x => x.ArrivalRows)
            .HasForeignKey(x => x.MarkId);
    }
}
