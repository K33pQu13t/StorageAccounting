using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "DOCTYPE")
            .ToTable(t =>
            {
                t.HasComment("Тип документа");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasIdentityOptions(startValue: 100)
            .UseIdentityAlwaysColumn();

        builder
            .HasMany(x => x.Documents)
            .WithOne(x => x.DocumentType)
            .HasForeignKey(x => x.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.OperationDocumentTypes)
            .WithOne(x => x.DocumentType)
            .HasForeignKey(x => x.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
