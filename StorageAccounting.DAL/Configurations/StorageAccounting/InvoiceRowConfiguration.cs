using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;
internal class InvoiceRowConfiguration : IEntityTypeConfiguration<InvoiceRow>
{
    public void Configure(EntityTypeBuilder<InvoiceRow> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "INVOICEROW")
            .ToTable(t =>
            {
                t.HasComment("Позиция документа накладной");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.PositionId).HasColumnName("Id_Position");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.InvoiceRows)
            .HasForeignKey(x => x.PositionId);
    }
}
