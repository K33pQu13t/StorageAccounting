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

        builder
            .HasMany(x => x.Documents)
            .WithOne(x => x.DocumentType);
    }
}
