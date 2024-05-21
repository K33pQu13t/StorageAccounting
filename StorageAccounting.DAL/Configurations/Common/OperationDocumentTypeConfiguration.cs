using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;

internal class OperationDocumentTypeConfiguration : IEntityTypeConfiguration<OperationDocumentType>
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
        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn();

        builder.Property(x => x.OperationTypeId).HasColumnName("Id_OperType");
        builder.Property(x => x.DocumentTypeId).HasColumnName("Id_DocType");

        builder
            .HasOne(x => x.OperationType)
            .WithMany(x => x.OperationDocumentTypes)
            .HasForeignKey(x => x.OperationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.DocumentType)
            .WithMany(x => x.OperationDocumentTypes)
            .HasForeignKey(x => x.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
