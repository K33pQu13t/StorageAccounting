using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Item;

namespace StorageAccounting.DAL.Configurations.Item;

internal class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(x => x.Id);

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
