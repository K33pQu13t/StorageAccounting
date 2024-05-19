using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;

public class OperationDocumentTypeConfiguration : IEntityTypeConfiguration<OperationDocumentType>
{
    public void Configure(EntityTypeBuilder<OperationDocumentType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "OPERDOCTYPE")
            .ToTable(t =>
            {
                t.HasComment("Связь операции с типом документа");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OperationId).HasColumnName("ID_OPER");
        builder.Property(x => x.DocumentTypeId).HasColumnName("ID_DOCTYPE");

        builder
            .HasOne(x => x.Operation)
            .WithMany(x => x.OperationDocumentTypes);

        builder
            .HasOne(x => x.DocumentType)
            .WithMany(x => x.OperationDocumentTypes);
    }
}
