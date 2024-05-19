using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;

internal class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "SHIPMENT")
            .ToTable(t =>
            {
                t.HasComment("Документ отгрузки наружу");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentId).HasColumnName("ID_DOCUMENT");

        builder.Property(x => x.PartnerId).HasColumnName("ID_PARTNER");

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Shipments);

        builder
            .HasOne(x => x.Partner)
            .WithMany(x => x.Shipments);
    }
}
