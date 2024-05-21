using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;

internal class ShipmentRowConfiguration : IEntityTypeConfiguration<ShipmentRow>
{
    public void Configure(EntityTypeBuilder<ShipmentRow> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "SHIPMENTROW")
            .ToTable(t =>
            {
                t.HasComment("Позиция документа отгрузки наружу");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PositionId).HasColumnName("Id_Position");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.ShipmentRows)
            .HasForeignKey(x => x.PositionId);
    }
}
