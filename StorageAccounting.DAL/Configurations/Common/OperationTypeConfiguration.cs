using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Common;

namespace StorageAccounting.Domain.Configurations.Common;
internal class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
{
    public void Configure(EntityTypeBuilder<OperationType> builder)
    {
        builder
            .ToTable(schema: "COMMON", name: "OPERTYPE")
            .ToTable(t =>
            {
                t.HasComment("Тип операции");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasIdentityOptions(startValue: 100)
            .UseIdentityAlwaysColumn();

        builder
            .HasMany(x => x.Operations)
            .WithOne(x => x.OperationType)
            .HasForeignKey(x => x.OperationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.OperationDocumentTypes)
            .WithOne(x => x.OperationType)
            .HasForeignKey(x => x.OperationTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
