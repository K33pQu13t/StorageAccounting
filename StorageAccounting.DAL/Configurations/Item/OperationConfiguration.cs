using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Item;

namespace StorageAccounting.Domain.Configurations.Item;
internal class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder
            .ToTable(schema: "ITEM", name: "OPERATION")
            .ToTable(t =>
            {
                t.HasComment("Операция");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OperationTypeId).HasColumnName("ID_OPERTYPE");

        builder.Property(x => x.DocumentId).HasColumnName("ID_DOCUMENT");

        builder.Property(x => x.StateId).HasColumnName("ID_STATE");

        builder
            .HasOne(x => x.OperationType)
            .WithMany(x => x.Operations);

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Operations);

        builder
            .HasOne(x => x.State)
            .WithMany(x => x.Operations);

        builder
            .HasMany(x => x.Moves)
            .WithOne(x => x.Operation);
    }
}
