using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;

internal class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "TRANSFER")
            .ToTable(t =>
            {
                t.HasComment("Документ внутреннего перемещения продукции между складами");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentId).HasColumnName("ID_DOCUMENT");

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Transfers);
    }
}
