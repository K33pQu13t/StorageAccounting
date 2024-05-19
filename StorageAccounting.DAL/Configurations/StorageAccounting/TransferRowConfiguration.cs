using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;

internal class TransferRowConfiguration : IEntityTypeConfiguration<TransferRow>
{
    public void Configure(EntityTypeBuilder<TransferRow> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "TRANSFERROW")
            .ToTable(t =>
            {
                t.HasComment("Позиция документа внутреннего перемещения продукции между складами");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PositionId).HasColumnName("ID_POSITION");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.TransferRows);
    }
}
