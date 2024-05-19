using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;

internal class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "DOCUMENT")
            .ToTable(t =>
            {
                t.HasComment("Документ");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentTypeId).HasColumnName("ID_DOCTYPE");

        builder
            .HasOne(x => x.DocumentType)
            .WithMany(x => x.Documents);

        builder
            .HasMany(x => x.Positions)
            .WithOne(x => x.Document);

        builder
            .HasMany(x => x.Operations)
            .WithOne(x => x.Document);
    }
}
